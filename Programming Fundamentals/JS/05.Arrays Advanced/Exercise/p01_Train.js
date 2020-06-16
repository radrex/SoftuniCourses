function solve(tokens = []) {
  let wagons = tokens.shift().split(' ').map(Number);
  let wagonMaxCapacity = +tokens.shift();

  while (tokens.length !== 0) {
    let command = tokens.shift().split(' ');

    if (command[0] === 'Add') {
      wagons.push(+command[1]);
    } else {
      let passengers = +command[0];
      const index = wagons.findIndex(x => x + passengers <= wagonMaxCapacity);
      if (index !== -1) {
        wagons[index] += passengers;
      }
    }
  }
  
  console.log(wagons.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['32 54 21 12 4 0 23',
       '75',
       'Add 10',
       'Add 0',
       '30',
       '10',
       '75']);

solve(['0 0 0 10 2 4',
       '10',
       'Add 10',
       '10',
       '10',
       '10',
       '8',
       '6']);