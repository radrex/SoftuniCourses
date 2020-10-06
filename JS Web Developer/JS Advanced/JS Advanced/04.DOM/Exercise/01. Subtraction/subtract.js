function subtract() {
  let num1 = document.getElementById('firstNumber');
  let num2 = document.getElementById('secondNumber');

  if (num1 === null || num2 === null) {
    throw new Error('Something went wrong...');
  }
  document.getElementById('result').textContent = num1.value - num2.value;
}