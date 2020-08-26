function solve(a, b, c) {
  let result;
  if (a > b && a > c) { result = a; }
  else if (b > a && b > c) { result = b; }
  else if (c > a && c > b) { result = c; }

  console.log(`The largest number is ${result}.`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(5, -3, 16);

/*
    function solve(...params) {
      return `The largest number is ${Math.max(...params)}.`
    }

    solve(5, -3, 16);
*/

//----------------------------------------------------------------------------
/*
    function solve(a, b, c) {
      return `The largest number is ${[a,b,c].sort((a, b) => a - b).pop()}.`
    }

    function solve(...params) {
      return `The largest number is ${params.sort((a, b) => a - b).pop()}.`
    }

    console.log(solve(5, -3, 16));
    console.log(solve(-3, -5, -22.5));
    console.log(solve(-3, -5, -22.5, 2, 102, 4));
*/

