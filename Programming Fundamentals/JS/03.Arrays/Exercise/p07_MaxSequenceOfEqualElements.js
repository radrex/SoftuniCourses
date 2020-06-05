function solve(nums = []) {
  let biggestNum = nums[nums.length - 1];
  let biggestCount = 1;

  let currentNum = nums[nums.length - 1];
  let currentCount = 1;

  for (let i = nums.length - 1; i > 0; i--) {
    if (nums[i] !== nums[i - 1]) {
      currentNum = nums[i - 1];
      currentCount = 1;
      continue;
    }

    currentCount++;

    if (currentCount >= biggestCount) {
      biggestCount = currentCount;
      biggestNum = currentNum;
    }
  }

  let sequence = '';
  for (let i = 0; i < biggestCount; i++) {
    sequence += `${biggestNum} `;
  }

  console.log(sequence.trimEnd());
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
solve([1, 1, 1, 2, 3, 1, 3, 3]);
solve([4, 4, 4, 4]);
solve([0, 1, 1, 5, 2, 2, 6, 3, 3]);
