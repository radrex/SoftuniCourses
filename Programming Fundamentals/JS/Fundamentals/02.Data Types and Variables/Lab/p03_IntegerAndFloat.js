function solve(num1, num2, num3) {
  let sum = num1 + num2 + num3;
  sum % 1 === 0 ? sum += ' - Integer' : sum += ' - Float';
  //---- SHORTER VERSION ----
  //sum += (sum % 1 === 0) ? ' - Integer' : ' - Float';
  
  console.log(sum);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(9, 100, 1.1);
solve(100, 200, 303);
