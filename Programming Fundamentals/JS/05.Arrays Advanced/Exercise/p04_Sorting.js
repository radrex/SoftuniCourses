function solve(arr = []) {
  arr.sort((a, b) => a - b);

  let sorted = [];
  while (arr.length !== 0) {
    sorted.push(arr.pop());
    sorted.push(arr.shift());
  }

  console.log(sorted.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([1, 21, 3, 52, 69, 63, 31, 2, 18, 94]);
