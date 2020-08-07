function solve(arr = []) {
  let sum = 0;
  arr[0] < arr[1] ? [...arr[2]].forEach(x => (x > arr[0] && x < arr[1]) ? sum += x.charCodeAt(0) : sum += 0) :
                    [...arr[2]].forEach(x => (x > arr[1] && x < arr[0]) ? sum += x.charCodeAt(0) : sum += 0);

  console.log(sum);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['.', '@', 'dsg12gr5653feee5']);
solve(['?', 'E', '@ABCEF']);
solve(['a', '1', 'jfe392$#@j24ui9ne#@$']);
