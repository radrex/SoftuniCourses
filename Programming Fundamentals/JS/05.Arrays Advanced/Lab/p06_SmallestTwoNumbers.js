function solve(arr = []) {
  let sortedAscending = arr.sort((a, b) => a - b);
  console.log(sortedAscending.slice(0, 2).join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);