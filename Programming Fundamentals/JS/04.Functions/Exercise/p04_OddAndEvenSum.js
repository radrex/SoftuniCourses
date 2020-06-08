function printOddAndEvenSum(number) {
  let oddSum = 0;
  let evenSum = 0;

  for (let digit of number.toString()) {
    digit = digit - '0';
    digit % 2 !== 0 ? oddSum += digit : evenSum += digit;
  }

  console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
printOddAndEvenSum(1000435);
printOddAndEvenSum(3495892137259234);