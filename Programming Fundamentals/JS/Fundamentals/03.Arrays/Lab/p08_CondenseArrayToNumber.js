function solve(arr) {
  while (arr.length !== 1) {
    let length = arr.length - 1;
    let condensed = [];

    for (let i = 0; i < length; i++) {
      condensed[i] = arr[i] + arr[i + 1];
    }

    arr = condensed;
  }

  console.log(arr[0]);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([2,10,3]);
solve([5,0,4,1,2]);
solve([1]);
