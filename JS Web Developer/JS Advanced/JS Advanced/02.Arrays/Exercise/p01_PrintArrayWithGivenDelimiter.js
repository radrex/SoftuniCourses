function solve(input = []) {
  let arr = input.slice();
  let delimiter = arr.pop();

  return arr.join(delimiter);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['One', 'Two', 'Three', 'Four', 'Five', '-']));
console.log(solve(['How about no?', 'I','will', 'not', 'do', 'it!', '_']))
