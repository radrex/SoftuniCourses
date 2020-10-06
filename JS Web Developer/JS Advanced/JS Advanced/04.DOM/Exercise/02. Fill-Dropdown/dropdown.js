function addItem() {
  //----------- GET DATA -----------
  let textElement = document.getElementById('newItemText');
  let valueElement = document.getElementById('newItemValue');
  let menuElement = document.getElementById('menu');

  if (textElement === null || valueElement === null || menuElement === null) {
    throw new Error('Something went wrong...');
  }

  if (textElement.value === '' || valueElement.value === '') {
    return alert('Fill both fields please.');
  }

  //-------- CONSTRUCT HTML --------
  let option = document.createElement('option');
  option.setAttribute('value', valueElement.value);
  option.innerHTML = textElement.value;
  menuElement.appendChild(option);

  //----------- CLEAR INPUT FIELDS ----------
  textElement.value = '';
  valueElement.value = '';
}