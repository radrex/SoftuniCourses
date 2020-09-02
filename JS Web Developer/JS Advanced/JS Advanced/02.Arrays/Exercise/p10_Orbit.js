function solve(tokens = []) {
  let width = tokens[0];
  let height = tokens[1];
  let x = tokens[2];
  let y = tokens[3];

  // INITIALIZE MATRIX
  let matrix = [];
  for (let i = 0; i < width; i++) {
    matrix.push([]);
  }

  for (let row = 0; row < width; row++) {
    for (let i = 0; i < height; i++) {
      matrix[row][i] = Math.max(Math.abs(row - x), Math.abs(i - y)) + 1;
    }
  }

  for (let row of matrix) {
    console.log(row.join(' '));
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([4, 4, 0, 0]);
solve([5, 5, 2, 2]);
solve([3, 3, 2, 2]);