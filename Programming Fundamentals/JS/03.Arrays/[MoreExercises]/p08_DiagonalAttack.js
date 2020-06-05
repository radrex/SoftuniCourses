function solve(arr) {
  let matrix = [];
  for (let row = 0; row < arr.length; row++) {
    matrix[row] = arr[row].split(' ').map(x => +x);
  }

  let diagonalsIndexes = [];

  let diagonalSum1 = 0;
  for (let i = 0; i < matrix.length; i++) {
    diagonalsIndexes.push([i, i]);
    diagonalSum1 += matrix[i][i];
  }

  let diagonalSum2 = 0;
  for (let row = 0, i = matrix.length - 1; row < matrix.length; row++, i--) {
    diagonalsIndexes.push([row, i]);
    diagonalSum2 += matrix[row][i];
  }

  if (diagonalSum1 === diagonalSum2) {
    // CHECK FOR DUPLICATE POSITION [x, y]
    let middleIndex = -1;
    if (matrix.length % 2 !== 0) {
      middleIndex = matrix.length / 2;
    }

    // REMOVE DUPLICATE POSITION [x, y]
    if (middleIndex !== -1) {
      diagonalsIndexes.splice(middleIndex, 1);
    }

    // SORT POSITIONS
    diagonalsIndexes = diagonalsIndexes.sort((x, y) => (x > y) - (x < y));

    // SET EVERY CELL THAT'S ON THE DIAGONALS TO DIAGONAL SUM
    let position = 0;
    for (let row = 0; row < matrix.length; row++) {
      for (let i = 0; i < matrix[row].length; i++) {
        let positions = diagonalsIndexes[position];
        if (row === positions[0] && i === positions[1]) {
          position++;
          continue;
        } else {
          matrix[row][i] = diagonalSum1;
        }
      }
    }
  }

  // PRINT FINAL MATRIX
  for (let row of matrix) {
    console.log(row.join(' '));
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['5 3 12 3 1', 
       '11 4 23 2 5',
       '101 12 3 21 10',
       '1 4 5 2 2',
       '5 22 33 11 1']);
      
solve(['1 1 1',
       '1 1 1',
       '1 1 0']);
