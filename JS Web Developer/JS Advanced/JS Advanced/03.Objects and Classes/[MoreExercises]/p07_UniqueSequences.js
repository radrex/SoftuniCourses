function solve(input = []) {
  let arrays = input.slice().map(x => JSON.parse(x).sort((a, b) => b - a)).sort((a, b) => a.length - b.length);
  for (let i = 0; i < arrays.length - 1; i++) {
    for (let j = i + 1; j < arrays.length; j++) {
      if (JSON.stringify(arrays[i]) === JSON.stringify(arrays[j])) {
        arrays.splice(j, 1);
        j--;
        i--;
      }
    }
  }

  return arrays.map(x => `[${x.join(', ')}]\n`).join('').trim();                    
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(["[-3, -2, -1, 0, 1, 2, 3, 4]",
                   "[10, 1, -17, 0, 2, 13]",
                   "[4, -3, 3, -2, 2, -1, 1, 0]"]));

console.log(solve(["[7.14, 7.180, 7.339, 80.099]",
                   "[7.339, 80.0990, 7.140000, 7.18]",
                   "[7.339, 7.180, 7.14, 80.099]"]));
