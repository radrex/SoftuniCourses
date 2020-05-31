function solve(number, precision) {
  if(precision > 15) {
    precision = 15;
  }

  console.log(parseFloat(number.toFixed(precision)));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(3.1415926535897932384626433832795, 2);
solve(10.5, 3);
