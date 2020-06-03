function solve(nums = [], magicSum = 0) {
  for (let n1 = 0; n1 < nums.length - 1; n1++) {
    for (let n2 = n1 + 1; n2 <= nums.length - 1; n2++) {
      if (nums[n1] + nums[n2] === magicSum) {
        console.log(`${nums[n1]} ${nums[n2]}`);
      }
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([1, 7, 6, 2, 19, 23], 8);
solve([14, 20, 60, 13, 7, 19, 8], 27);
solve([1, 2, 3, 4, 5, 6], 6);
