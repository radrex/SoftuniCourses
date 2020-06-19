function solve(arr = []) {
  let coordinates = arr.pop().split(' ');
  let matrix = [];
  let kills = 0;
  let totalDmg = 0;

  for (let row = 0; row < arr.length; row++) {
    matrix[row] = arr[row].split(' ').map(Number);
  }

  while (coordinates.length !== 0) {
    let bombCoordinates = coordinates.shift().split(',').map(Number);
    let row = bombCoordinates[0];
    let i = bombCoordinates[1];

    //---- VALID BOMB INDEX (IN RANGE OF THE MATRIX) AND BOMB IS ACTIVE ----
    if (isBombValid(row, i)) {
      let dmg = matrix[row][i];
      //---- SAME ROW ----
      if (hasCellBackwards(i))            takeDmg(row, i - 1, dmg);
      if (hasCellForward(row, i))         takeDmg(row, i + 1, dmg);
      //---- TOP ROW ----
      if (hasRowAbove(row)) {
                                          takeDmg(row - 1, i, dmg);
        if (hasCellBackwards(i))          takeDmg(row - 1, i - 1, dmg);
        if (hasCellForward(row, i))       takeDmg(row - 1, i + 1, dmg);
      }
      //---- BOTTOM ROW ----
      if (hasRowBelow(row)) {
                                          takeDmg(row + 1, i, dmg);
        if (hasCellBackwards(i))          takeDmg(row + 1, i - 1, dmg);
        if (hasCellForward(row, i))       takeDmg(row + 1, i + 1, dmg);
      }
      //---- DESTROY BOMB ----
      totalDmg += dmg;
      kills++;
      matrix[row][i] = 0;
    }
  }
  killRest();
  
  console.log(totalDmg);
  console.log(kills);

  //------------------------------------------------- FUNCTIONS -------------------------------------------------
  function takeDmg(row, i, dmg) { matrix[row][i] - dmg <= 0 ? matrix[row][i] = 0 : matrix[row][i] -= dmg; }
  function isBombValid(row, i) { return (row >= 0 && row < matrix.length && i >= 0 && i < matrix[row].length) && matrix[row][i] > 0; }

  function hasCellBackwards(i) { return i - 1 > -1; }
  function hasCellForward(row, i) { return i + 1 < matrix[row].length; }
  function hasRowAbove(row) { return row - 1 > -1; }
  function hasRowBelow(row) { return row + 1 < matrix.length; }

  function killRest() {
    for (let row = 0; row < matrix.length; row++) {
      for (let i = 0; i < matrix[row].length; i++) {
        if (matrix[row][i] > 0) {
          totalDmg += matrix[row][i];
          matrix[row][i] = 0;
          kills++;
        }
      }
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['10 10 10',
       '10 10 10',
       '10 10 10',
       '0,0']);

solve(['5 10 15 20',
       '10 10 10 10',
       '10 15 10 10',
       '10 10 10 10',
       '2,2 0,1']);
