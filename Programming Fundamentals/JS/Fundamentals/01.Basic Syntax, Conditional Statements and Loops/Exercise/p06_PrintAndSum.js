function solve(start, end) {
  let sequence = '';
  let sum = 0;
  for (let i = start; i <= end; i++) {
      sequence += i + ' ';
      sum += i;
  }
  console.log(sequence.trimRight());
  console.log(`Sum: ${sum}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(5, 10);
solve(0, 26);
solve(50, 60);
