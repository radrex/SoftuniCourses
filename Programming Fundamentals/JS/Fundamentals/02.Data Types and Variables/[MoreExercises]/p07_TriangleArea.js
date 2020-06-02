function solve(a, b, c) {
  let s = (a + b + c) / 2.0;
  let area = Math.sqrt(s * (s - a) * (s - b) * (s - c));
  console.log(area);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(2, 3.5, 4);