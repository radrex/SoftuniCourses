function solve(rows, cols) {
  //---- INITIALIZE EMPTY MATRIX ----
  let matrix = [];

  for (let row = 0; row < rows; row++) {
    matrix[row] = [];
    for (let col = 0; col < cols; col++) {
      matrix[row][col] = 0;
    }
  }

  //---- FILL MATRIX ----
  let counter = 1;

  let row = 0;
  let col = 0;

  let isRow = true;
  let isRowReversed = false;
  let isColReversed = false;

  while (matrix.some(x => x.includes(0))) {
    //---- ROW ORIENTED ----
    if (isRow) {
      //---- RIGHT ----
      if (!isRowReversed) {
        for (let i = 0; i < cols; i++) {
          if (matrix[row][i] === 0) {
            matrix[row][i] = counter;
            col = i;
            counter++;
          }
        }

        isRow = false; // for NEXT iteration (COLUMN ORIENTED)
        isRowReversed = true; // for NEXT + 1 iteration (ROW ORIENTED, LEFT)
      }
      //---- LEFT ----
      else {
        for (let i = col; i >= 0; i--) {
          if (matrix[row][i] === 0) {
            matrix[row][i] = counter;
            col = i;
            counter++;
          }
        }

        isRow = false; // for NEXT iteration (COLUMN ORIENTED)
        isRowReversed = false; // for NEXT + 1 iteration (ROW ORIENTED, RIGHT)
      }
    }
    //---- COLUMN ORIENTED ----
    else {
      //---- DOWN ----
      if (!isColReversed) {
        for (let i = 0; i < rows; i++) {
          if (matrix[i][col] === 0) {
            matrix[i][col] = counter;
            row = i;
            counter++;
          }
        }

        isRow = true; // for NEXT iteration (ROW ORIENTED)
        isColReversed = true; // for NEXT + 1 iteration (COLUMN ORIENTED, UP)
      }
      //---- UP ----
      else {
        for (let i = row; i >= 0; i--) {
          if (matrix[i][col] === 0) {
            matrix[i][col] = counter;
            row = i;
            counter++;
          }
        }

        isRow = true; // for NEXT iteration (ROW ORIENTED)
        isColReversed = false; // for NEXT + 1 iteration (COLUMN ORIENTED, DOWN)
      }
    }
  }

  for (let row of matrix) {
    console.log(row.join(' '));
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(3, 3);
solve(5, 5);