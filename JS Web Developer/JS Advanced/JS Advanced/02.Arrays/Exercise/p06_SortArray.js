function solve(input = []) {
  let arr = input.slice();
  return arr.sort((a, b) => a.length - b.length || a.localeCompare(b)).join('\n');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['alpha', 'beta', 'gamma']));
console.log(solve(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']));
console.log(solve(['test', 'Deny', 'omen', 'Default']));