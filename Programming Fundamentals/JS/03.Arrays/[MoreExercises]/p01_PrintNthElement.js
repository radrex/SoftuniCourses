function solve(arr = []) {
  let nthElements = [];
  let step = +arr.pop();

  for (let i = 0; i < arr.length; i += step) {
    nthElements.push(arr[i]);
  }

  console.log(nthElements.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['5', '20', '31', '4', '20', '2']);
solve(['dsa', 'asd', 'test', 'test', '2']);
solve(['1', '2', '3', '4', '5', '6']);

