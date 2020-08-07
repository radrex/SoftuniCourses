function solve(text) {
  text = [...text].reduce((acc, value) => value === acc.charAt(acc.length - 1) ? acc + '' : acc + value);
  console.log(text);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('aaaaabbbbbcdddeeeedssaa');
solve('qqqwerqwecccwd');

