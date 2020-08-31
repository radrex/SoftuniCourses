//------------------ IMPERATIVE APPROACH ------------------
function solve(matrix = []) {
  let result = matrix[0][0];
  for (let i = 0; i < matrix.length; i++) {
    for (let j = 0; j < matrix[i].length; j++) {
      if (matrix[i][j] > result) {
        result = matrix[i][j];
      }
    }
  }

  return result;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve([[20, 50, 10], [8, 33, 145]]));
console.log(solve([[3, 5, 7, 12], [-1, 4, 33, 2], [8, 3, 0, 4]]));

//------------------ DECLARATIVE APPROACH(ES) ------------------
/*
  function solve(matrix = []) {
    return Math.max(...matrix.flat(1));
    return Math.max(...matrix.reduce((a, b) => [...a, ...b], []));
    return Math.max(...matrix.reduce((a, b) => a.concat(b), []));
    
    //  [...a, ...b] // bad :-(
    //  a.concat(b) // good :-)
  
    //  [x, y].concat(a) // bad :-(
    //  [x, y, ...a]    // good :-)
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve([[20, 50, 10], [8, 33, 145]]));
  console.log(solve([[3, 5, 7, 12], [-1, 4, 33, 2], [8, 3, 0, 4]]));
*/
