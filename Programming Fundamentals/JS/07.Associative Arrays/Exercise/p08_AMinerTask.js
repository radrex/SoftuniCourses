function solve(arr = []) {
  let resources = {};

  while (arr.length !== 0) {
    let resource = arr.shift();
    let quantity = Number(arr.shift());

    if (!resources.hasOwnProperty(resource)) {
      resources[resource] = quantity;
    } else {
      resources[resource] += quantity;
    }
  }

  for (let [resource, quantity] of Object.entries(resources)) {
    console.log(`${resource} -> ${quantity}`);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Gold',
       '155',
       'Silver',
       '10',
       'Copper',
       '17']);

solve(['gold',
       '155',
       'silver',
       '10',
       'copper',
       '17',
       'gold',
       '15']);