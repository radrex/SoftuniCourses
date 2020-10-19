//---- WITH EVENT DELEGATION (attaching only 1 event listener and using 'target' to capture elements, without attaching event listener to each one of them) ----
function solve() {
  let table = document.getElementsByClassName('minimalistBlack')[0];

  if (table == null) {
    throw new Error('Something went wrong...');
  }

  table.addEventListener('click', function(evt) {
    if (evt.target && evt.target.nodeName === 'TD' && evt.target.parentElement.parentElement.nodeName === "TBODY") {
      let bgColor = evt.target.parentElement.style.backgroundColor;
      Array.from(evt.target.parentElement.parentElement.children).forEach(x => x.removeAttribute('style'));
      if (bgColor === '') {
        evt.target.parentElement.style.backgroundColor = '#413f5e';
      }
    }
  });
}
