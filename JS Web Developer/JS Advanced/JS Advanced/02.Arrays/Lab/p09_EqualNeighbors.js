//------------------ IMPERATIVE APPROACH ------------------
function solve(matrix = []) {
  let result = 0;

  for (let row = 0; row < matrix.length - 1; row++) {
    for (let i = 0; i < matrix[row].length; i++) {
      if (matrix[row][i] === matrix[row + 1][i]) {
        result++;
      }

      if (matrix[row][i] === matrix[row][i + 1]) {
        result++;
      }

      if (row === matrix.length - 2 && matrix[row + 1][i] === matrix[row + 1][i + 1]) {
        result++;
      }
    }
  }
  return result;
}

console.log(solve([['2', '3', '4', '7', '0'],
                   ['4', '0', '5', '3', '4'],
                   ['2', '3', '5', '4', '2'],
                   ['9', '8', '7', '5', '4']]));

console.log(solve([['test', 'yes', 'yo', 'ho'],
                   ['well', 'done', 'yo', '6'],
                   ['not', 'done', 'yet', '5']]));

console.log(solve([['2', '2', '5', '7', '4'],
                   ['4', '0', '5', '3', '4'],
                   ['2', '5', '5', '4', '2']]));

//------------------ DECLARATIVE APPROACH ------------------
/*
  function solve(matrix = []) {
    let result = 0;

    matrix.forEach(arr => result += intersectArray(arr)); // check each array in matrix for equal neigbours
    for (let i = 0; i < matrix.length - 1; i++) { // check arrays in matrix for equal neighbours
      result += intersectArrays(matrix[i], matrix[i + 1]);
    }
    return result;

    function intersectArrays(a, b) {
      return a.filter((element, index) => b[index] === element).length;
    }

    function intersectArray(arr) {
      return arr.reduce((acc, _, idx, array) => array[idx] === array[idx + 1] ? acc += 1 : acc += 0, 0);
    }
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve([['2', '3', '4', '7', '0'],
                    ['4', '0', '5', '3', '4'],
                    ['2', '3', '5', '4', '2'],
                    ['9', '8', '7', '5', '4']]));

  console.log(solve([['test', 'yes', 'yo', 'ho'],
                    ['well', 'done', 'yo', '6'],
                    ['not', 'done', 'yet', '5']]));

  console.log(solve([['2', '2', '5', '7', '4'],
                    ['4', '0', '5', '3', '4'],
                    ['2', '5', '5', '4', '2']]));
*/
