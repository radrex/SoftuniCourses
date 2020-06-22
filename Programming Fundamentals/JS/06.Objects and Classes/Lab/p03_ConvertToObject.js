function solve(json) {
  let person = JSON.parse(json);

  for (let key in person) {
    console.log(`${key}: ${person[key]}`);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('{"name": "George", "age": 40, "town": "Sofia"}');
