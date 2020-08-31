//------------------ IMPERATIVE / DECLARATIVE APPROACH ------------------
function solve(n, k) {
  n = +n;
  k = +k;

  let sequence = new Array(n);
  sequence[0] = 1;

  for (let i = 1; i < sequence.length; i++) {
    let start = i - k < 0 ? 0 : i - k;
    sequence[i] = sequence.slice(start, k + start).reduce((acc, value) => acc + value, 0);
  }

  return sequence.join(' ');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(6, 3));
console.log(solve(8, 2));
