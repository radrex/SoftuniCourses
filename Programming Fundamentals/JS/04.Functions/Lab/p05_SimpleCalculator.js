function calculate(a, b, operator) {
  const cases = {
    'multiply' : (a, b) => a * b,
    'divide' : (a, b) => a / b,
    'add' : (a, b) => a + b,
    'subtract' : (a, b) => a - b,
  }

  return cases[operator](a, b);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(calculate(5, 5, 'multiply'));
console.log(calculate(40, 8, 'divide'));
console.log(calculate(12, 19, 'add'));
console.log(calculate(50, 13, 'subtract'));

//--------------- DIFFERENT APPROACH ---------------
// function calculate(a, b, operator) {
//   switch (operator) {
//     case 'multiply':
//       let multiply = (a, b) => a * b;
//       console.log(multiply(a, b));
//       break;
//     case 'divide':
//       let divide = (a, b) => a / b;
//       console.log(divide(a, b));
//       break;
//     case 'add':
//       let add = (a, b) => a + b;
//       console.log(add(a, b));
//       break;
//     case 'subtract':
//       let subtract = (a, b) => a - b;
//       console.log(subtract(a, b));
//       break;
//   }
// }

// Don't copy the calling of the function in judge, you won't get any points, just the code above
// calculate(5, 5, 'multiply');
// calculate(40, 8, 'divide');
// calculate(12, 19, 'add');
// calculate(50, 13, 'subtract')


