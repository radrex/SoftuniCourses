//---------- USING EVENT DELEGATION (only 1 event listener) ----------
function attachEvents() {
  let textarea = document.getElementById('messages');
  let controlsDiv = document.getElementById('controls');
  let nameInput = document.getElementById('author');
  let messageInput = document.getElementById('content');

  if (nameInput == null || messageInput == null || textarea == null || controlsDiv == null) {
    throw new Error('Something went wrong...');
  }

  let uri = 'https://rest-messanger.firebaseio.com/messanger.json';
  const actions = {
    'Send': () => {
      if (nameInput.value !== '' && messageInput !== '') {
        fetch(uri, {
          method: 'POST',
          headers: { 'Content-type': 'application/json' },
          body: JSON.stringify({author: nameInput.value, content: messageInput.value }),
        });

        nameInput.value = '';
        messageInput.value = '';
      }
    },
    'Refresh': () => fetch(uri).then(x => x.json()).then(x => 
        textarea.innerHTML = Object.values(x).filter(y => y.author !== '' && y.content !== '')
                                             .map(p => `${p.author}: ${p.content}\n`)
      )
  };

  controlsDiv.addEventListener('click', function(evt) {
    if (evt.target && evt.target.nodeName === 'INPUT' && evt.target.type === 'button') {
      actions[evt.target.value]();
    }
  })
}

attachEvents();