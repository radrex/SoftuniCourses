function solve(min, max) {
  let result = 0;
  for(let i = +min; i <= +max; i++) {
    result += i;
  }
  return result;
}

/*
    function solve(min, max) {
      let result = 0;
      for(let i = Number(min); i <= Number(max); i++) {
        result += i;
      }
      return result;
    }
*/

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve("1", "5"));
console.log(solve("-8", "20"));
