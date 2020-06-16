function solve(arr = []) {
  // x --> item in array
  // i --> index of item
  // a --> array reference, (in this case "arr")
  arr = arr.filter((x, i, a) => a.indexOf(x) === i);

  //---- With Set ----
  // arr = [...new Set(arr)];

  console.log(arr.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([1, 2, 3, 4]);
solve([7, 8, 9, 7, 2, 3, 4, 1, 2]);
solve([20, 8, 12, 13, 4, 4, 8, 5]);
