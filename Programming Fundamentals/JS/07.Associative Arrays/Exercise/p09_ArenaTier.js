function solve(arr = []) {
  let gladiators = new Map();

  for (let i = 0; i < arr.length; i++) {
    if (arr[i].includes('Ave Cesar')) {
      break;
    }
    else if (arr[i].includes('vs')) {
      let [gladiator1, gladiator2] = arr[i].split(' vs ');

      if (gladiators.has(gladiator1) && gladiators.has(gladiator2)) {
        let hasCommonTechnique = [...gladiators.get(gladiator1).keys()].some(element => [...gladiators.get(gladiator2).keys()].includes(element));

        if (hasCommonTechnique) {
          let gladiator1Points = [...gladiators.get(gladiator1).values()].reduce((acc, value) => acc + value);
          let gladiator2Points = [...gladiators.get(gladiator2).values()].reduce((acc, value) => acc + value);

          gladiator1Points > gladiator2Points ? gladiators.delete(gladiator2) : gladiators.delete(gladiator1);
        }
      }
    } else {
      let [gladiator, technique, skill] = arr[i].split(' -> ');
      skill = Number(skill);

      if (!gladiators.has(gladiator)) {
        gladiators.set(gladiator, new Map());
        gladiators.get(gladiator).set(technique, skill);
      } else {
        if (!gladiators.get(gladiator).has(technique)) {
          gladiators.get(gladiator).set(technique, skill);
        } else {
          if (gladiators.get(gladiator).get(technique) < skill) {
            gladiators.get(gladiator).set(technique, skill);
          }
        }
      }
    }
  }

  gladiators = new Map([...gladiators].sort((a, b) => Array.from(b[1]).reduce((acc, value) => acc + value[1], 0) - 
                                                      Array.from(a[1]).reduce((acc, value) => acc + value[1], 0) || a[0].localeCompare(b[0])));
  for (let key of gladiators.keys()) {
    let value = gladiators.get(key);
    value = new Map(Array.from(value).sort((a, b) => b[1] - a[1] || a[0].localeCompare(b[0])));
    gladiators.set(key, value);
  }

  for (let gladiator of gladiators) {
    console.log(`${gladiator[0]}: ${[...gladiator[1]].reduce((acc, value) => acc + value[1], 0)} skill`);
    for (let technique of gladiator[1]) {
      console.log(`- ${technique[0]} <!> ${technique[1]}`);
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Peter -> BattleCry -> 400',
       'Alex -> PowerPunch -> 300',
       'Stefan -> Duck -> 200',
       'Stefan -> Tiger -> 250',
       'Ave Cesar']);

solve(['Pesho -> Duck -> 400',
       'Julius -> Shield -> 150',
       'Gladius -> Heal -> 200',
       'Gladius -> Support -> 250',
       'Gladius -> Shield -> 250',
       'Peter vs Gladius',
       'Gladius vs Julius',
       'Gladius vs Maximilian',
       'Ave Cesar']);