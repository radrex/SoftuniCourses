//---------- USING EVENT DELEGATION (only 1 event listener) ----------
function attachEvents() {
  let body = document.getElementsByTagName('body')[0];
  let ul = document.getElementById('phonebook');
  let personInput = document.getElementById('person');
  let phoneInput = document.getElementById('phone');

  if (body == null || ul == null || personInput == null || phoneInput == null) {
    throw new Error('Something went wrong...');
  }

  let uri = 'https://phonebook-nakov.firebaseio.com/phonebook.json';
  const actions = {
    'Load': () => fetch(uri).then(x => x.json()).then(x => 
                        ul.innerHTML = Object.entries(x).filter(p => p[1].person !== '' && p[1].phone !== '')
                        .map(p => `<li>${p[1].person}: ${p[1].phone}<button value="${p[0]}">Delete</button></li>`)
                        .join('')
                      ),
    'Create': () => {
      if (personInput.value !== '' && phoneInput.value !== '') {
        fetch(uri, {
          method: 'POST',
          headers: { 'Content-type': 'application/json' },
          body: JSON.stringify({person: personInput.value, phone: phoneInput.value }),
        });

        personInput.value = '';
        phoneInput.value = '';
      }
    },
    'Delete': (key) => {
      let deleteURI = `${uri.slice(0, 48)}/${key}.json`;
      fetch(deleteURI, { method: "DELETE" });
    }
  };

  body.addEventListener('click', function (evt) {
    if (evt.target && evt.target.nodeName === 'BUTTON') {
      actions[evt.target.textContent](evt.target.value);
    }
  });
}

attachEvents();