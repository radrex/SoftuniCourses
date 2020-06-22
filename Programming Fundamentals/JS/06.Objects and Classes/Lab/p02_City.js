function solve(name, area, population, country, postCode) {
  let city = {
    name,
    area,
    population,
    country,
    postCode,
  };

  let entries = Object.entries(city);
  for (let [key, value] of entries) {
    console.log(`${key} -> ${value}`);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve("Sofia"," 492", "1238438", "Bulgaria", "1000");
