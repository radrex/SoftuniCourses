function solve(arr = []) {
  let topIntegers = [];

  for (let i = 0; i < arr.length; i++) {
    let isTopInteger = true;
    for (let j = i + 1; j < arr.length; j++) {
      if (arr[i] <= arr[j]) {
        isTopInteger = false;
        break;
      }
    }

    if (isTopInteger) {
      topIntegers.push(arr[i]);
    }
  }

  console.log(topIntegers.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([1, 4, 3, 2]);
solve([14, 24, 3, 19, 15, 17]);
solve([41, 41, 34, 20]);
solve([27, 19, 42, 2, 13, 45, 48]);
