function solve(n, k) {
  let sequence = [1];

  while (sequence.length !== n) {
    let next = 0;

    for (let i = sequence.length - 1, times = k; i > -1 && times > 0; i--, times--) {
      next += sequence[i];
    }

    sequence[sequence.length] = next;
  }
  
  console.log(sequence.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(6, 3);
solve(8, 2);