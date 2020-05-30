function solve(typeOfDay, age) {
  switch (typeOfDay) {
    case "Weekday":
      if (age >= 0 && age <= 18) {
        console.log("12$");
      }
      else if (age > 18 && age <= 64) {
        console.log("18$");
      }
      else if (age > 64 && age <= 122) {
        console.log("12$");
      }
      else {
        console.log("Error!");
        return;
      }
      break;

    case "Weekend":
      if (age >= 0 && age <= 18) {
        console.log("15$");
      }
      else if (age > 18 && age <= 64) {
        console.log("20$");
      }
      else if (age > 64 && age <= 122) {
        console.log("15$");
      }
      else {
        console.log("Error!");
        return;
      }
      break;

    case "Holiday":
      if (age >= 0 && age <= 18) {
        console.log("5$");
      }
      else if (age > 18 && age <= 64) {
        console.log("12$");
      }
      else if (age > 64 && age <= 122) {
        console.log("10$");
      }
      else {
        console.log("Error!");
        return;
      }
      break;
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('Weekday', 42);
solve('Holiday', -12);
solve('Holiday', 15);
