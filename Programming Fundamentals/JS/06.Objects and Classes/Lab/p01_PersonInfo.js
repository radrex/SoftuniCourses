function solve(firstName, lastName, age) {
  let person = {
    firstName: firstName,
    lastName: lastName,
    age: age,
  };

  let entries = Object.entries(person);
  for (let [key, value] of entries) {
    console.log(`${key}: ${value}`);
  }

  // for (let key in person) {
  //   console.log(`${key}: ${person[key]}`);
  // }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve("Peter", "Pan", "20");
