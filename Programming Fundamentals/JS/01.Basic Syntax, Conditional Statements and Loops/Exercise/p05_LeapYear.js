function solve(year) {
  console.log((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0 ? 'yes' : 'no');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(1984);
solve(2003);
solve(4);
