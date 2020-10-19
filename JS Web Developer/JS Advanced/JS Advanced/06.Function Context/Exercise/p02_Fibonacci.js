function getFibonator() {
  let x = 1;
  let y = 1;
  let z = 0;

  return function getNext() {
    [z, x, y] = [x, y, x + y];
    return z;
  }
}

// Don't copy the code below in judge, you won't get any points, just the code above
let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13