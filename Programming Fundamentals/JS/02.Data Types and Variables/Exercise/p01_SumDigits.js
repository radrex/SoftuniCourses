function sumDigits(number) {
  let sum = 0;
  number = number.toString().split('');
  number.forEach(digit => sum += Number(digit));
  return sum;

  //---- Different approach ----
  // let sum = 0;
  // while (number > 0) {
  //   let lastDigit = number % 10;
  //   sum += lastDigit;
  //   number = Math.trunc(number / 10);
  // }
  // return sum;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(sumDigits(245678));
console.log(sumDigits(97561));
console.log(sumDigits(543));
