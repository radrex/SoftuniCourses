function solve(arr = [], rotations) {
  while (rotations-- !== 0) {
    let firstElement = arr.shift();
    arr.push(firstElement);
  }

  console.log(arr.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([51, 47, 32, 61, 21], 2);
solve([32, 21, 61, 1], 4);
solve([2, 4, 15, 31], 5);
