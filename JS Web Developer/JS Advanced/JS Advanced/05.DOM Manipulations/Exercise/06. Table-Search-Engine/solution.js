function solve() {
  let searchElement = document.getElementById('searchField');
  let btnElement = document.getElementById('searchBtn');
  let dataElements = Array.from(document.querySelectorAll('tbody > tr'));

  if (searchElement === null || btnElement === null) {
    throw new Error('Something went wrong...');
  }

  btnElement.addEventListener('click', function() {
    if (searchElement.value !== '') {
      let regex = new RegExp(searchElement.value, 'gim');
      dataElements.map(x => {
        x.classList.remove('select');
        if (x.textContent.match(regex) !== null) {
          x.classList.add('select');
        }
      });
      searchElement.value = '';
    } else {
      dataElements.map(x => x.classList.remove('select'));
    }
  });
}
