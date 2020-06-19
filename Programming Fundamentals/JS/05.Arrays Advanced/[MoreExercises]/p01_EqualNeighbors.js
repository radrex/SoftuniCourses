function getEqualPairs(matrix) {
  let equalPairs = 0;
  
  for (let row = 0; row < matrix.length; row++) {
    for (let i = 0; i < matrix[row].length; i++) {
      if (row !== matrix.length - 1 && matrix[row][i] === matrix[row + 1][i]) {
        equalPairs++;
      }

      if (i !== matrix[row].length - 1 && matrix[row][i] === matrix[row][i + 1]) {
        equalPairs++;
      }
    }
  }

  return equalPairs;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(getEqualPairs([['2', '3', '4', '7', '0'],
                           ['4', '0', '5', '3', '4'],
                           ['2', '3', '5', '4', '2'],
                           ['9', '8', '7', '5', '4']]));

console.log(getEqualPairs([['test', 'yes', 'yo', 'ho'],
                           ['well', 'done', 'yo', '6'],
                           ['not', 'done', 'yet', '5']]));
                      
console.log(getEqualPairs([[2, 2, 5, 7, 4],
                           [4, 0, 5, 3, 4],
                           [2, 5, 5, 4, 2]]));
