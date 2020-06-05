function solve(m, n) {
  for (let i = m; i >= n; i--) {
    console.log(i);
  }

  //---- With while loop ----
  // while (m >= n) {
  //   console.log(m--);
  // }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(5, 3);
solve(4, 1);
