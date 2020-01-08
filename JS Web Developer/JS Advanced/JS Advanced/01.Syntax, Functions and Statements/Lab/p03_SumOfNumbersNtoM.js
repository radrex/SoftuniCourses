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

console.log(solve("1", "5"));
console.log(solve("-8", "20"));
