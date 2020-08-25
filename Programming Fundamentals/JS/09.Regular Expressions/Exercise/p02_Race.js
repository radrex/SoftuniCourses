function solve(input = []) {
  let racers = new Map();
  let participants = input.shift().split(', ');
  for (let racer of participants) {
    if (!racers.has(racer)) {
      racers.set(racer, 0);
    }
  }

  for (let i = 0; i < input.length; i++) {
    if (input[i] === 'end of race') {
      break;
    }

    let racer = input[i].match(/[A-Za-z]+/g).join('');
    let distance = input[i].match(/\d/g).map(x => +x).reduce((acc, value) => acc + value);

    if (racers.has(racer)) {
      racers.set(racer, racers.get(racer) + distance);
    }
  }
  
  racers = [...racers].sort((a, b) => b[1] - a[1]);
  racers.length = 3;
  racers = new Map(racers);

  let place = 1;
  let nth = 'st';

  for (let racer of racers) {
    if (place === 2) { nth = 'nd'; }
    else if (place === 3) { nth = 'rd'; }

    console.log(`${place++}${nth} place: ${racer[0]}`)
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['George, Peter, Bill, Tom', 'G4e@55or%6g6!68e!!@', 'R1@!3a$y4456@', 'B5@i@#123ll', 'G@e54o$r6ge#', '7P%et^#e5346r', 'T$o553m&6', 'end of race']);
