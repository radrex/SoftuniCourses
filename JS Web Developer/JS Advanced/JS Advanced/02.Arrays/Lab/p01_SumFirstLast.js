function solve(numbers = []) {
  return +numbers[0] + +numbers[numbers.length - 1];
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));
