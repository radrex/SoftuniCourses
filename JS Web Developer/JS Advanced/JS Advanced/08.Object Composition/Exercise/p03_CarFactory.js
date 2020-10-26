function solve(requirements) {
  let engines = [{ power: 90, volume: 1800 }, { power: 120, volume: 2400 }, { power: 200, volume: 3500 }];
  let carriages = [{ type: 'hatchback', color: requirements.color }, { type: 'coupe', color: requirements.color }];
  let wheelsize = requirements.wheelsize % 2 === 0 ? requirements.wheelsize - 1 : requirements.wheelsize;

  return {
      model: requirements.model,
      engine: engines.filter(x => x.power >= requirements.power)[0],
      carriage: carriages.filter(x => x.type === requirements.carriage)[0],
      wheels: [wheelsize, wheelsize, wheelsize, wheelsize]
  }
}

// Don't copy the code below in judge, you won't get any points, just the code above
console.log(solve({ model: 'VW Golf II',
                    power: 90,
                    color: 'blue',
                    carriage: 'hatchback',
                    wheelsize: 14 }));

console.log(solve({ model: 'Opel Vectra',
                    power: 110,
                    color: 'grey',
                    carriage: 'coupe',
                    wheelsize: 17 }));