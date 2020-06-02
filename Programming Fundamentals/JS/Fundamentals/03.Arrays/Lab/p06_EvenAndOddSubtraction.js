function solve(arr) {
  let evenSum = 0;
  let oddSum = 0;

  for (let num of arr) {
    num -= 0; // ASCII hack
    num % 2 === 0 ? evenSum += num : oddSum += num;
  }

  console.log(evenSum - oddSum);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([1,2,3,4,5,6]);
solve([3,5,7,9]);
solve([2,4,6,8,10]);
