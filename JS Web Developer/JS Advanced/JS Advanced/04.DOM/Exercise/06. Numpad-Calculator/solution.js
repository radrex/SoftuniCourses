function solve() {
  const keys = Array.from(document.getElementsByClassName('keys'));
  const expressionOutput = document.getElementById('expressionOutput');
  const result = document.getElementById('resultOutput');
  const clearButton = document.querySelector('.clear');
  let operand;
  let firstNumber = '';
  let secondNumber = '';

  const calculator = {
      '+': (a, b) => a + b,
      '-': (a, b) => a - b,
      '*': (a, b) => a * b,
      '/': (a, b) => a / b
  }

  keys.map(key => key.addEventListener('click', function (evt) {
      const currentSelection = evt.target.value;

      clearButton.addEventListener('click', () => {
          expressionOutput.textContent = '';
          result.textContent = '';
          firstNumber = '';
          secondNumber = '';
          operand = '';
      })

      if (+currentSelection || currentSelection == '.' || currentSelection == '0') {
          if (!operand) {
              firstNumber += currentSelection;
              expressionOutput.textContent += currentSelection;
          } else {
              secondNumber += currentSelection;
              expressionOutput.textContent += currentSelection
          }
      } else if (calculator.hasOwnProperty(currentSelection)) {
          operand = currentSelection;
          expressionOutput.textContent += ` ${operand} `;
      } else if (currentSelection == '=') {
          if (+firstNumber && +secondNumber) { //check if both are valid nums
              result.textContent = calculator[operand](+firstNumber, +secondNumber);
          } else {
              result.textContent = 'NaN';
          }
      }
  }))
}