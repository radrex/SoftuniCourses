//------------------ IMPERATIVE APPROACH ------------------
function solve(matrix = []) {
  let firstDiagonalSum = 0;
  let secondDiagonalSum = 0;

  for (let row = 0; row < matrix.length; row++) {
    firstDiagonalSum += matrix[row][row];
    secondDiagonalSum += matrix[row][matrix.length - 1 - row];    
  }

  return [firstDiagonalSum, secondDiagonalSum].join(' ')
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve([[20, 40], [10, 60]]));
console.log(solve([[3, 5, 17], [-1, 7, 14], [1, -8, 89]]));

//------------------ DECLARATIVE APPROACH ------------------
/*
  function solve(matrix = []) {
    return matrix.reduce((result, row, i, arr) => {
      result[0] += row[i];
      result[1] += row[arr.length - 1 - i];
      return result;
    }, [0, 0]).join(' ');
  }
  
  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve([[20, 40], [10, 60]]));
  console.log(solve([[3, 5, 17], [-1, 7, 14], [1, -8, 89]]));
*/
