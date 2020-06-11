function solve(arr = []) {
  let resultArr = [];
  while (arr.length !== 0) {
    let element = arr.shift();
    element < 0 ? resultArr.unshift(element) : resultArr.push(element);
  }

  for (const element of resultArr) {
    console.log(element);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);
