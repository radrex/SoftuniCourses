//---- WITH EVENT DELEGATION (attaching only 1 event listener and using 'target' to capture child elements, without attaching event listener to each one of them) ----
function solve() {
  let jsonInputElement = document.getElementsByTagName('textarea')[0];
  let divElement = document.getElementById('exercise');
  let tbodyElement = document.getElementsByTagName('tbody')[0];
  let resultElement = document.getElementsByTagName('textarea')[1];

  if (jsonInputElement === null || divElement === null || tbodyElement === null || resultElement === null) {
    throw new Error('Something went wrong...');
  }

  divElement.addEventListener('click', function(evt) {
    if (evt.target && evt.target.nodeName === 'BUTTON') {
      switch (evt.target.textContent) {
        case 'Generate':
          generateProducts(jsonInputElement.value, tbodyElement);
          break;
      
        case 'Buy':
          let checkedProducts = Array.from(document.querySelectorAll("input[type='checkbox']:checked"));
          buyProducts(checkedProducts, resultElement);
          break;

        default:
          break;
      }
    }
  });

  //------------------- FUNCTIONS -------------------
  function generateProducts(json, tbodyElement) {
    let objArr = JSON.parse(json);
    for (let i = 0; i < objArr.length; i++) {
      let tr = document.createElement('tr');
      let tds = new Map([['img', null],
                         ['name', null],
                         ['price', null],
                         ['decFactor', null],
                         ['checkbox', null]]); // using this if json is passed in different order

      for (let [prop, value] of Object.entries(objArr[i])) {
        let td = document.createElement('td');
        let tdChild = document['createElement'](prop);
        tdChild.nodeName === 'IMG' ? tdChild.setAttribute('src', value) : tdChild.textContent = value;
        td.appendChild(tdChild);

        tds.set(prop, td);
      }

      let td = document.createElement('td');
      let checkbox = document.createElement('input');
      checkbox.type = 'checkbox';
      td.appendChild(checkbox);

      tds.set('checkbox', td);
      tds.forEach(x => tr.appendChild(x));
      
      tbodyElement.appendChild(tr);
    }
  }

  function buyProducts(checkedProducts, resultElement) {
    let totalPrice = 0;
    let decFactor = 0;
    
    resultElement.textContent = `Bought furniture: ${checkedProducts.reduce((acc, value) => {
      acc.push(value.parentNode.previousElementSibling.previousElementSibling.previousElementSibling.textContent);
      totalPrice += Number(value.parentNode.previousSibling.previousSibling.textContent);
      decFactor += Number(value.parentNode.previousSibling.textContent);
      return acc;
    }, []).join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${decFactor / checkedProducts.length}`;
  }
}