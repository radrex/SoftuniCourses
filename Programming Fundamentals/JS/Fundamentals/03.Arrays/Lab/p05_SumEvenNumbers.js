function sumEvenNumbers(arr) {
  let sum = 0;
  for (let num of arr) {
    num -= 0; // ASCII hack
    if (num % 2 === 0) {
      sum += num;
    }
  }

  console.log(sum);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
sumEvenNumbers(['1','2','3','4','5','6']);
sumEvenNumbers(['3','5','7','9']);
sumEvenNumbers(['2','4','6','8','10']);
