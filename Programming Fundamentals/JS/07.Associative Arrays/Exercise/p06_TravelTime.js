function solve(arr = []) {
  let destinations = new Map();

  while (arr.length !== 0) {
    let [country, town, cost] = arr.shift().split(' > ');
    cost = Number(cost);
    if (!destinations.has(country)) {
      destinations.set(country, new Map());
      destinations.get(country).set(town, cost);
    } else {
      if (!destinations.get(country).has(town)) {
        destinations.get(country).set(town, cost);
      } else {
        let oldCost = destinations.get(country).get(town);
        if (cost < oldCost) {
          destinations.get(country).set(town, cost);
        }
      }
    }
  }

  destinations = new Map(Array.from(destinations).sort());

  for (let key of destinations.keys()) {
    let value = destinations.get(key);
    value = new Map(Array.from(value).sort((a, b) => a[1] - b[1]));
    destinations.set(key, value);
  }

  for (let destination of destinations) {
    let output = `${destination[0]} -> `;
    for (let town of destination[1]) {
      output += `${town[0]} -> ${town[1]} `;
    }
    
    console.log(output.trimEnd());
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(["Bulgaria > Sofia > 500",
       "Bulgaria > Sopot > 800",
       "France > Paris > 2000",
       "Albania > Tirana > 1000",
       "Bulgaria > Sofia > 200"]);
