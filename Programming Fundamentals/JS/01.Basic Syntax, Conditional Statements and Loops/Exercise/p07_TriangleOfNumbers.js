function solve(n) {
  for (let i = 1; i <= n; i++) {
    console.log(`${i} `.repeat(i));
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(3);
solve(5);
solve(6);
