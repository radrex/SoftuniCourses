function addItem() {
  let inputElement = document.getElementById('newItemText');
  let ulElement = document.getElementById('items');

  if (inputElement === null || ulElement === null) {
    throw new Error('Something went wrong...');
  }

  if (inputElement.value !== '') {
    let li = document.createElement('li');
    li.textContent = inputElement.value;
    ulElement.appendChild(li);
    inputElement.value = '';
  }
}