function solve(input = []) {
  let cars = input.slice()
                  .map(x => x.split(' | '))
                  .reduce((map, [car, model, produced]) => {
                    if (!map.has(car)) {
                      map.set(car, new Map([[model, +produced]]));
                      return map;
                    }

                    let currentCar = map.get(car);
                    if (!currentCar.has(model)) {
                      currentCar.set(model, +produced);
                      return map;
                    }

                    produced = +produced + currentCar.get(model);
                    currentCar.set(model, produced);
                    return map;

                  }, new Map());

  let output = '';
  for (let [car, value] of cars) {
    output += `${car}\n`;
    for (let [model, produced] of value) {
      output += `###${model} -> ${produced}\n`;
    }
  }

  return output.trim();
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Audi | Q7 | 1000',
                   'Audi | Q6 | 100',
                   'BMW | X5 | 1000',
                   'BMW | X6 | 100',
                   'Citroen | C4 | 123',
                   'Volga | GAZ-24 | 1000000',
                   'Lada | Niva | 1000000',
                   'Lada | Jigula | 1000000',
                   'Citroen | C4 | 22',
                   'Citroen | C5 | 10']));
