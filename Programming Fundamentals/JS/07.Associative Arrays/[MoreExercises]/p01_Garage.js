function solve(arr = []) {
  let garages = new Map();

  while (arr.length !== 0) {
    let [garage, carInfo] = arr.shift().split(' - ');
    carInfo = carInfo.replace(/:/g, ' -');

    if (!garages.has(garage)) {
      garages.set(garage, [carInfo]);
    } else {
      garages.get(garage).push(carInfo);
    }
  }

  for (let [garage, cars] of garages) {
    console.log(`Garage № ${garage}`);
    cars.forEach(x => console.log(`--- ${x}`));
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['1 - color: blue, fuel type: diesel',
       '1 - color: red, manufacture: Audi',
       '2 - fuel type: petrol',
       '4 - color: dark blue, fuel type: diesel, manufacture: Fiat']);

