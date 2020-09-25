//------------------ IMPERATIVE APPROACH ------------------
function solve(input = []) {
  let result = [];
  for (const iterator of input) {
    let [name, level, items] = iterator.split(' / ');
    level = +level;
    items = items ? items.split(', ') : [];
    result.push({ name, level, items });
  }

  return JSON.stringify(result);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Isacc / 25 / Apple, GravityGun',
                   'Derek / 12 / BarrelVest, DestructionSword',
                   'Hes / 1 / Desolator, Sentinel, Antara']));

console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']));

//------------------ DECLARATIVE APPROACH ------------------ I ----
/*
  function solve(input = []) {
    return JSON.stringify(input.slice()
                              .map(x => x.split(' / '))
                              .reduce((acc, value) => {
                                let hero = {
                                  name: value[0],
                                  level: +value[1],
                                  items: value[2] ? value[2].split(', ') : [],
                                }
                              
                                acc.push(hero);
                                return acc;
                              }, []));
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['Isacc / 25 / Apple, GravityGun',
                    'Derek / 12 / BarrelVest, DestructionSword',
                    'Hes / 1 / Desolator, Sentinel, Antara']));

  console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']));
  console.log(solve([]));
*/
