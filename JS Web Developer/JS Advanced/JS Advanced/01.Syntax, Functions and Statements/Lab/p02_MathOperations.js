function solve(x, y, operator) {
  let result;
  switch(operator) {
    case "+": result = x + y; break;
    case "-": result = x - y; break;
    case "/": result = x / y; break;
    case "*": result = x * y; break;
    case "%": result = x % y; break;
    case "**": result = x ** y; break;
  }

  console.log(result);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(5, 6, "+");

//-------------- With eval (Anti-pattern) ---------------
/*
    function solve(operator, x, y) {
      return eval(`${x} ${operator} ${y}`)
    }

    console.log(
      solve("+", 5, 6)
    )
*/

//-------------- Generic with eval (Anti-pattern), polish notation ---------------
/*
    function solve(operator, ...params) {
      return params.reduce((a, b) => eval(`${a} ${operator} ${b}`), params.shift())
    }

    console.log(
      solve("-", -10, 5, 1, -5, 12, 5)
    )
*/

//-------------- Generic with mapper -> removes eval Anti-pattern ---------------
/*
    const operationsMap = {
      "+": (x, y) => x + y,
      "-": (x, y) => x - y,
      "/": (x, y) => x / y,
      "*": (x, y) => x * y,
      "%": (x, y) => x % y,
      "**": (x, y) => x ** y,
    }

    function solve(operator, ...params) {
      return params.reduce((a, b) => operationsMap[operator](a, Number(b)), Number(params.shift()))
    }

    console.log(
      solve("+", 1, 2, 3, 4)
    )
*/

//-------------- Generic with mapper -> removes eval Anti-pattern ---------------
/*
    function add(x, y) {
      return x + y;
    }

    function subtract(x, y) {
      return x - y;
    }

    const operationsMap = {
      "+": add,
      "-": subtract,
    }

    function solve(operator, ...params) {
      return params.reduce((a, b) => operationsMap[operator](a, Number(b)), Number(params.shift()))
    }

    console.log(
      solve("+", 1, 2, 3, 4)
    )
*/