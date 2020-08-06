function solve(arr = []) {
  let armies = new Map();

  while (arr.length !== 0) {
    let tokens = arr.shift();

    if (tokens.endsWith('arrives')) {
      let leader = tokens.replace('arrives', '').trimEnd();
      armies.set(leader, new Map());
      continue;
    } else if (tokens.endsWith('defeated')) {
      let leader = tokens.replace('defeated', '').trimEnd();
      if (armies.has(leader)) {
        armies.delete(leader);
      }
      continue;
    }

    tokens = tokens.split(/: |, | \+ /);
    switch (tokens.length) {
      case 2:
        for (let key of armies.keys()) {
          if (armies.get(key).has(tokens[0])) {
            let army = armies.get(key).get(tokens[0]);
            army += +tokens[1];
            armies.get(key).set(tokens[0], army);
          }
        }
        break;

      case 3:
        if (armies.has(tokens[0])) {
          armies.get(tokens[0]).set(tokens[1], +tokens[2]);
        }
        break;
    
      default:
        break;
    }
  }

  armies = new Map([...armies].sort((a, b) => [...b[1]].reduce((acc, value) => acc + value[1], 0) - [...a[1]].reduce((acc, value) => acc + value[1], 0)));
  for (let key of armies.keys()) {
    let value = armies.get(key);
    value = new Map([...value].sort((a, b) => b[1] - a[1]));
    armies.set(key, value);
  }

  for (let general of armies) {
    console.log(`${general[0]}: ${[...general[1]].reduce((acc, value) => acc + value[1], 0)}`);
    for (let army of general[1]) {
      console.log(`>>> ${army[0]} - ${army[1]}`);
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Rick Burr arrives',
       'Fergus: Wexamp, 30245',
       'Rick Burr: Juard, 50000',
       'Findlay arrives',
       'Findlay: Britox, 34540',
       'Wexamp + 6000',
       'Juard + 1350',
       'Britox + 4500',
       'Porter arrives',
       'Porter: Legion, 55000',
       'Legion + 302',
       'Rick Burr defeated',
       'Porter: Retix, 3205']);