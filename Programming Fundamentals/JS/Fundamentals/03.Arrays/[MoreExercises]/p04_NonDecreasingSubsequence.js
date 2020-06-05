function solve(nums = []) {
  for (let i = 0; i < nums.length - 1; i++) {
    if (nums[i] > nums[i + 1]) {
      nums.splice(i + 1, 1);
      i--;
    }
  }

  console.log(nums.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([1, 3, 8, 4, 10, 12, 3, 2, 24]);
solve([1, 2, 3, 4]);
solve([20, 3, 2, 15, 6, 1]);
