function solve(numOne, numTwo, numThree) {
  let result = '';
  if (numOne == 0 || numTwo == 0 || numThree == 0) {
    result = 'Positive';
  } else if (numOne > 0 && numTwo > 0 && numThree > 0) {
    result = 'Positive';
  } else if (numOne > 0 && numTwo > 0 && numThree < 0) {
    result = 'Negative';
  } else if (numOne > 0 && numTwo < 0 && numThree > 0) {
    result = 'Negative';
  } else if (numOne > 0 && numTwo < 0 && numThree < 0) {
    result = 'Positive';
  } else if (numOne < 0 && numTwo > 0 && numThree > 0) {
    result = 'Negative';
  } else if (numOne < 0 && numTwo > 0 && numThree < 0) {
    result = 'Positive';
  } else if (numOne < 0 && numTwo < 0 && numThree > 0) {
    result = 'Positive';
  } else if (numOne < 0 && numTwo < 0 && numThree < 0) {
    result = 'Negative';
  }

  console.log(result);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(5, 12, -15);
solve(-6, -12, 14);
solve(-1, -2, -3);
solve(1, 0, 1);
