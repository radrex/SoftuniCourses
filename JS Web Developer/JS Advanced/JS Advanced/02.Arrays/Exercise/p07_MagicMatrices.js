//------------------ DECLARATIVE APPROACH ------------------ I ---- DISTINCT using a SET
function solve(input = []) {
  let matrice = input.slice();

  let areRowsEqual = new Set(matrice.map(row => row.reduce((a, b) => a + b))).size === 1;
  let areColsEqual = new Set(matrice.reduce((a, b) => a.map((element, index) => element + b[index]))).size === 1;

  return areRowsEqual && areColsEqual;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve([[4, 5, 6],
                   [6, 5, 4],
                   [5, 5, 5]]));

console.log(solve([[11, 32, 45],
                   [21, 0, 1],
                   [21, 1, 1]]));
                
console.log(solve([[1, 0, 0],
                   [0, 0, 1],
                   [0, 1, 0]]));

//------------------ DECLARATIVE APPROACH ------------------ II --- Check each element
/*
  function solve(input = []) {
    let matrice = input.slice();

    let areRowsEqual = matrice.map(row => row.reduce((a, b) => a + b))
                              .every((x, _, arr) => x === arr[0]);

    let areColsEqual = matrice.reduce((a, b) => a.map((element, index) => element + b[index]))
                              .every((x, _, arr) => x === arr[0]);

    return areRowsEqual && areColsEqual;
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve([[4, 5, 6],
                     [6, 5, 4],
                     [5, 5, 5]]));

  console.log(solve([[11, 32, 45],
                     [21, 0, 1],
                     [21, 1, 1]]));

  console.log(solve([[1, 0, 0],
                     [0, 0, 1],
                     [0, 1, 0]]));
*/

