function solve(str, char, result) {
  let res = str.replace('_', char);
  console.log(res === result ? 'Matched' : 'Not Matched');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('Str_ng', 'I', 'Strong');
solve('Str_ng', 'i', 'String');
