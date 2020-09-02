//------------------ DECLARATIVE / IMPERATIVE APPROACH ------------------
function solve(input = []) {
  let arr = input.slice();

  return arr.reduce((acc, value) => {
    if (acc.length === 0 || acc[acc.length - 1] <= value) {
      acc.push(value);
    }
    return acc;
  } ,[]).join('\n');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(solve([1, 2, 3, 4]));
console.log(solve([20, 3, 2, 15, 6, 1]));
