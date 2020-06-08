function printMatrix(n) {
  let matrix = initializeMatrix(n);
  matrix.forEach(row => console.log(row.join(' ')));
  
  function initializeMatrix(n) {
    let matrix = [];
    for (let row = 0; row < n; row++) {
      matrix[row] = [];
      for (let i = 0; i < n; i++) {
        matrix[row][i] = n;
      }
    }
    return matrix;
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
printMatrix(3);
printMatrix(7);
printMatrix(2);
