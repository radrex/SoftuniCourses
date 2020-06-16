function solve(arr = []) {
  arr.sort((a, b) => a.length === b.length ? a.localeCompare(b) : a.length - b.length);

  for (const element of arr) {
    console.log(element);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(["alpha", "beta", "gamma"]);
solve(["Isacc", "Theodor", "Jack", "Harrison", "George"]);
