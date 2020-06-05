function solve(arr = []) {
  let rotations = +arr.pop();

  while (rotations-- > 0) {
    let popped = arr.pop();
    arr.unshift(popped);
  }

  console.log(arr.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['1', '2', '3', '4', '2']);
solve(['Banana', 'Orange', 'Coconut', 'Apple', '15']);
