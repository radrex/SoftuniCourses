function solve(nums) {
  let odd = 1;
  let sum = 0;
  while (nums != 0) {
    console.log(odd);
    sum += odd;
    odd += 2;
    nums--;
  }

  console.log(`Sum: ${sum}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(5);
solve(3);
