function solve(number) {
  for (let i = 1; i <= number; i++) {
    let digits = i.toString().split('');
    let sum = 0;

    digits.forEach(digit => {
      let d = digit - '0'; // ASCII hack hehehe
      sum += d;
    });

    switch (sum) {
      case 5:
      case 7:
      case 11:
        console.log(`${i} -> True`);
        break;
      default:
        console.log(`${i} -> False`);
        break;
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(15);
