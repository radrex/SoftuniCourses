function solve(yield) {
  let extractedSpices = 0;
  let days = 0;

  while (yield >= 100) {
    extractedSpices += (yield - 26);
    yield -= 10;
    days++;
  }

  if (extractedSpices - 26 >= 0) {
    extractedSpices -= 26;
  }

  console.log(days);
  console.log(extractedSpices);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(111);
