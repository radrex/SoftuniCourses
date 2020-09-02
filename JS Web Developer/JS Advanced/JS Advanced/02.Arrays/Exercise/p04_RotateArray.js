//------------------ IMPERATIVE APPROACH ------------------
function solve(input = []) {
  let arr = input.slice();
  let rotations = +arr.pop();

  for (let i = 0; i < rotations % arr.length; i++) {
    arr.unshift(arr.pop());
  }

  return arr.join(' ');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['1', '2', '3', '4', '2']));
console.log(solve(['Banana', 'Orange', 'Coconut', 'Apple', '15']));
