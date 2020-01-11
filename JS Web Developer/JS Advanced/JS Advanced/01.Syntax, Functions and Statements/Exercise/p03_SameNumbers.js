function solve(num) {
  let nums = String(num).split("");
  let isSame = true;
  let firstNum = nums[0];

  nums.forEach(function(num) {
    if (num != firstNum) {
      isSame = false;
    }
  });

  let sum = nums.map(Number).reduce((acc, cur) => acc + cur);

  console.log(isSame);
  console.log(sum);
}

solve(2222222);
solve(1234);

