function deleteByEmail() {
  let inputElement = document.getElementsByName('email')[0];
  let tableRecords = document.getElementsByTagName('tbody')[0];
  let bodyElement = document.getElementsByTagName('body')[0];

  if (inputElement === null || tableRecords === null || bodyElement === null) {
    throw new Error('Something went wrong...');
  }

  let errorElement = document.getElementById('result');
  if (errorElement === null) {
    errorElement = document.createElement('div');
    errorElement.setAttribute('id', 'result');
    bodyElement.appendChild(errorElement);
  }

  if (inputElement.value !== '') {
    let occurences = Array.from(tableRecords.children).filter(x => x.lastElementChild.textContent === inputElement.value);
    if (occurences.length === 0) {
      errorElement.textContent = 'Not found.';
    } else {
      occurences.forEach(x => x.remove());
      errorElement.textContent = 'Deleted.';
    }
    inputElement.value = '';
  }
}