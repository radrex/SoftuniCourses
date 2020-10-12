//---- WITH EVENT DELEGATION (attaching only 1 event listener on the parent element and using 'target' to capture child elements, without attaching event listener to each one of them) ----
function addItem() {
  let inputElement = document.getElementById('newText');
  let ulElement = document.getElementById('items');

  if (inputElement === null || ulElement === null) {
    throw new Error('Something went wrong...');
  }

  ulElement.addEventListener('click', function(evt) {
    if (evt.target && evt.target.nodeName === 'A') {
      evt.target.parentElement.remove();
    }
  });

  if (inputElement.value !== '') {
    let li = document.createElement('li');
    let a = document.createElement('a');
    a.setAttribute('href', '#');
    a.textContent = '[Delete]';
    li.textContent = inputElement.value;
    li.appendChild(a);
    ulElement.appendChild(li);
    inputElement.value = '';
  }
}

//---- WITHOUT EVENT DELEGATION (attaching event listeners on each list element) ----
/*
  function addItem() {
    let inputElement = document.getElementById('newText');
    let ulElement = document.getElementById('items');

    if (inputElement === null || ulElement === null) {
      throw new Error('Something went wrong...');
    }

    if (inputElement.value !== '') {
      let li = document.createElement('li');
      let a = document.createElement('a');
      
      a.setAttribute('href', '#');
      a.textContent = '[Delete]';
      a.addEventListener('click', function() {
        li.remove();
      });

      li.textContent = inputElement.value;
      li.appendChild(a);
      
      ulElement.appendChild(li);
      inputElement.value = '';
    }
  }
*/
