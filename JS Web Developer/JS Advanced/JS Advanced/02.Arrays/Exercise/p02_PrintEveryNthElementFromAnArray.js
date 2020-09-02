//------------------ IMPERATIVE APPROACH ------------------
function solve(input = []) {
  let arr = input.slice();
  let step = +arr.pop();

  let result = [];
  for (let i = 0; i < arr.length; i += step) {
    result.push(arr[i]);
  }

  return result.join('\n');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['5', '20', '31', '4', '20', '2']));
console.log(solve(['dsa','asd', 'test', 'tset', '2']));
console.log(solve(['1', '2','3', '4', '5', '6']));

//------------------ DECLARATIVE APPROACH ------------------
/*
  function solve(input = []) {
    let arr = input.slice();
    let step = +arr.pop();

    return arr.filter((x, idx) => idx % step === 0).join('\n');
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['5', '20', '31', '4', '20', '2']));
  console.log(solve(['dsa','asd', 'test', 'tset', '2']));
  console.log(solve(['1', '2','3', '4', '5', '6']));
*/
