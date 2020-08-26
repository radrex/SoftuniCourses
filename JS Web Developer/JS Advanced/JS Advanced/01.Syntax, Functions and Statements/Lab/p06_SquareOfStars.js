function solve(size = 5) {
  let result = new Array(size);

  for (let i = 0; i < size; i++) {
      result[i] = "* ".repeat(size).trim();
  }

  return result.join("\n");
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve());
console.log(solve(2));
console.log(solve(4));

/*
    function solve(delimiter, size = 5) {
      let result = new Array(size);

      for (let i = 0; i < size; i++) {
        result[i] = delimiter.repeat(size).split("").join(" ");
      }

      return result.join("\n");
    }

    console.log(solve("*"));
    console.log(solve("*", 10));
*/

