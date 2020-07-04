function solve(tokens = []) {
  let heroes = [];

  while (tokens.length !== 0) {
    let heroData = tokens.shift().split(' / ');

    let hero = {
      name: heroData[0],
      level: heroData[1],
      items: heroData[2].split(', '),
    }

    heroes.push(hero);
  }

  for (let hero of heroes.sort((a, b) => a.level - b.level)) {
    console.log(`Hero: ${hero.name}`);
    console.log(`level => ${hero.level}`);
    console.log(`items => ${hero.items.sort().join(', ')}`)
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(["Isacc / 25 / Apple, GravityGun",
       "Derek / 12 / BarrelVest, DestructionSword",
       "Hes / 1 / Desolator, Sentinel, Antara"]);
