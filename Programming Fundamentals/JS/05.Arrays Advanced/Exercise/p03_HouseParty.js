function solve(arr = []) {
  let guests = [];
  for (let i = 0; i < arr.length; i++) {
    let tokens = arr[i].split(' ');
    if (guests.includes(tokens[0])) {
      tokens[2] === 'going!' ? console.log(`${tokens[0]} is already in the list!`) : guests = guests.filter(g => g !== tokens[0]);
    } else {
      tokens[2] === 'going!' ? guests.push(tokens[0]) : console.log(`${tokens[0]} is not in the list!`);
    }
  }

  for (let guest of guests) {
    console.log(guest);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Allie is going!',
       'George is going!',
       'John is not going!',
       'George is not going!']);

solve(['Tom is going!',
       'Annie is going!',
       'Tom is going!',
       'Garry is going!',
       'Jerry is going!']);