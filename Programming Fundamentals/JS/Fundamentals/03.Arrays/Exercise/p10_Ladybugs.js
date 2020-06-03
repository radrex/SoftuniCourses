function solve(tokens = []) {
  let fieldSize = +tokens[0];
  let ladyBugs = [];
  
  for (let i = 0; i < fieldSize; i++) { // Initialize field
    ladyBugs[i] = 0;
  }

  let initialIndexes = tokens[1].split(' ').map(index => +index);

  for (let i = 0; i < ladyBugs.length; i++) { // Fill bugs on field
    if (initialIndexes.includes(i)) {
      ladyBugs[i] = 1;
    }
  }

  //------------------------------------------------------------------------------------------
  for (let i = 2; i < tokens.length; i++) {
    let command = tokens[i].split(' ');

    if (command[0].toLowerCase() !== 'end') {
      let index = +command[0];

      if (index < 0 || index >= ladyBugs.length) {   // If index is inside the field
        continue;
      }

      if (ladyBugs[index] === 0) {  // cell is empty (NO Lady Bug)
        continue;
      }

      //------------- Fly like the wind -------------
      let direction = command[1];
      let flyLength = +command[2];

      if (flyLength < 0) { // If flyLength is negative, change direction, and make it positive
        flyLength = Math.abs(flyLength);
        switch (direction) {
          case 'right':
            direction = 'left';
            break;
          case 'left':
            direction = 'right';
            break;
        }
      }

      ladyBugs[index] = 0; // Lift off in 3...2...1
      let isBugFlying = true;

      while (isBugFlying) {
        switch (direction) {
          case 'right':
            if (index + flyLength >= ladyBugs.length) { // Lady Bug flew away (outside field) 
              isBugFlying = false;
            } else {
              if (ladyBugs[index + flyLength] === 0) { //  is cell empty (no Lady Bug at index)
                ladyBugs[index + flyLength] = 1; // Lady Bug landed
                isBugFlying = false;
              } else {
                isBugFlying = true; // Lady Bug continues to fly
                index += flyLength;
              }
            }
            break;

          case 'left':
            if (index - flyLength < 0) { // Lady Bug flew away (outside field)
              isBugFlying = false;
            } else {
              if (ladyBugs[index - flyLength] === 0) { //  is cell empty (no Lady Bug at index)
                ladyBugs[index - flyLength] = 1; // Lady Bug landed
                isBugFlying = false;
              } else {
                isBugFlying = true; // Lady Bug continues to fly
                index -= flyLength;
              }
            }
            break;
        }
      }
    }
  }

  console.log(ladyBugs.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([3, '0 1', '0 right 1', '2 right 1']);
solve([ 3, '0 1 2', '0 right 1', '1 right 1', '2 right 1']);
solve([ 5, '3', '3 left 2', '1 left -2']);
