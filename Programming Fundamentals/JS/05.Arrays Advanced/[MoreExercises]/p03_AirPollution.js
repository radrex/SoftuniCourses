function solve(map, affectingForces) {
  for (let row = 0; row < map.length; row++) {
    map[row] = map[row].split(' ').map(Number);
  }

  while (affectingForces.length !== 0) {
    let [affectingForce, param] = affectingForces.shift().split(' ');

    switch (affectingForce) {
      case 'breeze':
        let row = Number(param);
        for (let i = 0; i < map[row].length; i++) {
          (map[row][i] - 15 < 0) ? map[row][i] = 0 : map[row][i] -= 15;
        }
        break;

      case 'gale':
        let col = Number(param);
        for (let i = 0; i < map.length; i++) {
          (map[i][col] - 20 < 0) ? map[i][col] = 0 : map[i][col] -= 20;
        }
        break;

      case 'smog':
        let pollution = Number(param);
        for (let row = 0; row < map.length; row++) {
          for (let i = 0; i < map[row].length; i++) {
            map[row][i] += pollution;
          }
        }
        break;

      default:
        break;
    }
  }

  let pollutedAreas = [];

  for (let row = 0; row < map.length; row++) {
    for (let i = 0; i < map[row].length; i++) {
      if (map[row][i] >= 50) {
        pollutedAreas.push(`[${row}-${i}]`);
      }
    }
  }

  console.log(pollutedAreas.length !== 0 ? `Polluted areas: ${pollutedAreas.join(', ')}` : `No polluted areas`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(["5 7 72 14 4",
       "41 35 37 27 33",
       "23 16 27 42 12",
       "2 20 28 39 14",
       "16 34 31 10 24"], ["breeze 1", "gale 2", "smog 25"]);

solve(["5 7 3 28 32",
       "41 12 49 30 33",
       "3 16 20 42 12",
       "2 20 10 39 14",
       "7 34 4 27 24"], [ "smog 11", "gale 3", "breeze 1", "smog 2"]);

solve(["5 7 2 14 4",
       "21 14 2 5 3",
       "3 16 7 42 12",
       "2 20 8 39 14",
       "7 34 1 10 24"], ["breeze 1", "gale 2", "smog 35"]);
