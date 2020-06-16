function solve(numbers = [], bombParameters = []) {
  let bombNumber = bombParameters[0];
  let bombPower = bombParameters[1];

  for (let i = 0; i < bombPower; i++) {
    for (let k = 0; k < numbers.length; k++) {
      if (numbers[k] === bombNumber) {
        if (k - 1 >= 0) {
          numbers.splice(k - 1, 1);
          k--;
        }

        if (k + 1 < numbers.length) {
          numbers.splice(k + 1, 1);
        }
      }
    }
  }

  numbers = numbers.filter(n => n !== bombNumber);
  console.log(numbers.reduce((acc, value) => acc + value, 0));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([1, 2, 2, 4, 2, 2, 2, 9], [4, 2]);
solve([1, 4, 4, 2, 8, 9, 1], [9, 3]);
solve([1, 7, 7, 1, 2, 3], [7, 1]);
solve([1, 1, 2, 1, 1, 1, 2, 1, 1, 1], [2, 1]);
