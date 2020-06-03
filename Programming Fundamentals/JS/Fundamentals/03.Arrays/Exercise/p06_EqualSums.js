function solve(nums = []) {
  if (nums.length === 1) {
    console.log(0);
    return;
  }

  for (let i = 0; i <= nums.length - 1; i++) {
    let leftSum = 0;
    let rightSum = 0;

    for (let left = i - 1; left >= 0; left--) {
      leftSum += nums[left];
    }

    for (let right = i + 1; right < nums.length; right++) {
      rightSum += nums[right];
    }

    if (leftSum === rightSum) {
      console.log(i);
      return;
    }
  }

  console.log("no");
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([1, 2, 3, 3]);
solve([1, 2]);
solve([1]);
solve([1, 2, 3]);
solve([10, 5, 5, 99, 3, 4, 2, 5, 1, 1, 4]);
