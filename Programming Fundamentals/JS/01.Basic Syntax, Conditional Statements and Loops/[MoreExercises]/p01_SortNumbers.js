function solve(num1, num2, num3) {
  let max = Math.max(Math.max(num1, num2), num3);
  let min = Math.min(Math.min(num1, num2), num3);
  let mid = (num1 + num2 + num3) - (max + min);

  console.log(max);
  console.log(mid);
  console.log(min);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(2, 1, 3);
solve(-2, 1, 3);
solve(0, 0, 2);
