function addAndSubtract(a, b, c) {
  function add(a, b) { return a + b; }
  function subtract(a, b) { return a - b; }

  let addResult = add(a, b);
  let subtractResult = subtract(addResult, c);
  
  return subtractResult;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(addAndSubtract(23, 6, 10));
console.log(addAndSubtract(1, 17, 30));
console.log(addAndSubtract(42, 58, 100));
