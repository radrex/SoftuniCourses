function solve(num1, op, num2) {
  const cases = {
    '+': (a, b) => a + b,
    '-': (a, b) => a - b,
    '*': (a, b) => a * b,
    '/': (a, b) => a / b,
  };

  return cases[op](num1, num2).toFixed(2)

  //---- LONGER APPROACH ----
  // switch (op) {
  //   case '+':
  //     return (num1 + num2).toFixed(2);
  //     break;
  //   case '-':
  //     return (num1 - num2).toFixed(2);
  //     break;
  //   case '*':
  //     return (num1 * num2).toFixed(2);
  //     break;
  //   case '/':
  //     return (num1 / num2).toFixed(2);
  //     break;

  //   default:
  //     break;
  // }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(5, '+', 10));
console.log(solve(25.5, '-', 3));
