//---- WITH EVENT DELEGATION (attaching only 1 event listener and using 'target' to capture elements, without attaching event listener to each one of them) ----
function solve() {
  let container = document.getElementsByClassName('container')[0];
  let box = document.querySelector('#box');

  if (container === null || box === null) {
    throw new Error('Something went wrong...');
  }

  container.addEventListener('click', function(evt) {
    if (evt.target && evt.target.nodeName === 'BUTTON') {
      if (evt.target.nextElementSibling.style.display === '' || evt.target.nextElementSibling.style.display === 'none') {
        evt.target.nextElementSibling.style.display = 'block';
      } else {
        evt.target.nextElementSibling.style.display = 'none';
        box.style.backgroundColor = 'black';
        box.style.color = 'white';
      }
    }

    if (evt.target && evt.target.nodeName === 'LI') {
      box.style.backgroundColor = evt.target.textContent;
      box.style.color = 'black';
    }
  });
}