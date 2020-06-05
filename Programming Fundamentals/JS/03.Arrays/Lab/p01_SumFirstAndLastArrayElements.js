function solve(input) {
  let firstElement = Number(input.shift());
  let lastElement = Number(input.pop());
  console.log(firstElement + lastElement);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['20', '30', '40']);
solve(['10', '17', '22', '33']);
solve(['11', '58', '69']);
