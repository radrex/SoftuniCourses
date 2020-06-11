function printFirstAndLastKNumbers(arr = []) {
  let k = arr.shift();
  let slice1 = arr.slice(0, k);
  let slice2 = arr.slice(arr.length - k, arr.length);
  console.log(slice1.join(' '));
  console.log(slice2.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
printFirstAndLastKNumbers([2, 7, 8, 9]);
printFirstAndLastKNumbers([3, 6, 7, 8, 9]);
