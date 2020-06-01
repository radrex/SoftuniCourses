function solve(centuries) {
  let years = centuries * 100;
  let days = Math.trunc(years * 365.2422);
  let hours = 24 * days;
  let minutes = 60 * hours;

  console.log(`${centuries} centuries = ${years} years = ${days} days = ${hours} hours = ${minutes} minutes`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(1);
solve(5);
