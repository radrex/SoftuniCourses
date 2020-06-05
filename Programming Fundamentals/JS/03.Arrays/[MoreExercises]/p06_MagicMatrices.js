function isMagicSquare(matrix) {
  let sum = 0;
  matrix[0].forEach(x => sum += x);

  //---- CHECKING ROWS ----
  for (let row = 0; row < matrix.length; row++) {
    let comparingSum = 0;
    for (let i = 0; i < matrix[row].length; i++) {
      comparingSum += matrix[row][i];
    }

    if (sum !== comparingSum) {
      return false;
    }
  }

  //---- CHECKING COLS ----
  for (let i = 0; i < matrix.length; i++) {
    let comparingSum = 0;
    for (let col = 0; col < matrix[i].length; col++) {
      comparingSum += matrix[col][i];
    }

    if (sum !== comparingSum) {
      return false;
    }
  }
  return true;

  //---- CHECKING DIAGONALS ----
  // let diagonal1Sum = 0;
  // for (let i = 0; i < matrix.length; i++) {
  //   diagonal1Sum += matrix[i][i];

  //   if (sum !== diagonal1Sum) {
  //     return false;
  //   }
  // }

  // let diagonal2Sum = 0;
  // for (let row = 0, i = matrix.length - 1; row < matrix.length; row++, i--) {
  //   diagonal2Sum += matrix[row][i];

  //   if (sum !== diagonal2Sum) {
  //     return false;
  //   }
  // }
  //return true;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(isMagicSquare([[4, 5, 6],
                          [6, 5, 4],
                          [5, 5, 5]]));

console.log(isMagicSquare([[11, 32, 45],
                          [21, 0, 1],
                          [21, 1, 1]]));

console.log(isMagicSquare([[1, 0, 0], 
                           [0, 0, 1], 
                           [0, 1, 0]]));