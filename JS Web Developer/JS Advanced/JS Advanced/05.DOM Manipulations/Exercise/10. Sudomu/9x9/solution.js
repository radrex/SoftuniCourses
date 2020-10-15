//---- WITH EVENT DELEGATION (attaching only 1 event listener and using 'target' to capture elements, without attaching event listener to each one of them) ----
function solve() {
  let tfootElement = document.getElementsByTagName('tfoot')[0];
  let inputElements = document.getElementsByTagName('input');
  let tableElement = document.getElementsByTagName('table')[0];
  let divElement = document.getElementById('check');

  if (tfootElement === null || inputElements.length !== 9 || tableElement === null || divElement === null) {
    throw new Error('Something went wrong...');
  }

  tfootElement.addEventListener('click', function(evt) {
    if (evt.target && evt.target.nodeName === 'BUTTON') {
      switch (evt.target.textContent) {
        case 'Quick Check':
          let sudomuElements = Array.from(inputElements).map(x => +x.value);
          if (isCorrectlyFilled(sudomuElements) && isSolved(sudomuElements)) {
            tableElement.style.border = '2px solid green';
            divElement.style.color = 'green';
            divElement.firstElementChild.textContent = 'You solve it! Congratulations!';
            return;
          }

          tableElement.style.border = '2px solid red';
          divElement.style.color = 'red';
          divElement.firstElementChild.textContent = 'NOP! You are not done yet...';
          break;
      
        case 'Clear':
          Array.from(inputElements).map(x => x.value = '');
          tableElement.removeAttribute('style');
          divElement.removeAttribute('style');
          divElement.firstElementChild.textContent = '';
          break;

        default:
          break;
      }
    }
  });

  function isCorrectlyFilled(sudomuElements) {
    return sudomuElements.every(x => x >= 1 && x <= 3);
  }

  function isSolved(sudomuElements) {
    let sudomuMatrix = sudomuElements.reduce((acc, value, idx) => (idx % 3 == 0 ? acc.push([value]) : acc[acc.length-1].push(value)) && acc, []);

    for (let i = 0; i < sudomuMatrix.length; i++) {
      let setCheck = new Set([...sudomuMatrix[i]]);
      if (setCheck.size !== 3) {
        return false;
      }
    }
    
    sudomuMatrix = sudomuMatrix[0].map((_, idx) => sudomuMatrix.map(row => row[idx])); // TRANSPOSE
    for (let i = 0; i < sudomuMatrix.length; i++) {
      let setCheck = new Set([...sudomuMatrix[i]]);
      if (setCheck.size !== 3) {
        return false;
      }
    }

    return true;
  }
}