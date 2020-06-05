function solve(num) {
  let sum = 0;
  num = num.toString();
  for (let i = 0; i < num.length; i++) {
    sum += (+num[i]);
  }

  console.log(sum.toString().includes('9') ? `${num} Amazing? True` : `${num} Amazing? False`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(1233);
solve(999);
solve(583472);
