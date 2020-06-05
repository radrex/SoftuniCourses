function solve(arr = []) {
  const reducer = (accumulator, currentValue) => accumulator + currentValue;
  let oldSum = arr.reduce(reducer);

  for (let i = 0; i < arr.length; i++) {
    arr[i] % 2 === 0 ? arr[i] += i : arr[i] -= i;
  }
  console.log(arr);
  console.log(oldSum);
  console.log(arr.reduce(reducer));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([5, 15, 23, 56, 35]);
solve([-5, 11, 3, 0, 2]);
