function solve(grade) {
  if (grade >= 5.50) {
    console.log("Excellent");
  } else {
    console.log("Not excellent");
  }

  //------- WITH TERNARY OP -------
  // console.log(grade >= 5.50 ? "Excellent" : "Not excellent")
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(6.00);
solve(5.50);
solve(5.40);