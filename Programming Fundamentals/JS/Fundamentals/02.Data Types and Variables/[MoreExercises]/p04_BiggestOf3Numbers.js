function solve(num1, num2, num3) {
  let biggestNumber = num1;

  if (num1 > num2 && num1 > num3) {
    biggestNumber = num1;
  }
  else if (num2 > num1 && num2 > num3) {
    biggestNumber = num2;
  }
  else if (num3 > num1 && num3 > num1) {
    biggestNumber = num3;
  }

  console.log(biggestNumber);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(-2, 7, 3);
solve(130, 5, 99);
solve(43, 43.2, 43.1);
