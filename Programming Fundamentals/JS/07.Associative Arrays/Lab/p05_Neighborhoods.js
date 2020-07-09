function solve(arr = []) {
  let map = new Map();
  let neighbourhoods = arr[0].split(', ');
  
  for (let neighbourhood of neighbourhoods) {
    map.set(neighbourhood, []);
  }

  for (let i = 1; i < arr.length; i++) {
    let [neighbourhood, person] = arr[i].split(' - ');

    if (neighbourhoods.includes(neighbourhood)) {
      map.get(neighbourhood).push(person);
    }
  }

  map = Array.from(map).sort((a, b) => b[1].length - a[1].length);
  
  for (let kvp of map) {
    console.log(`${kvp[0]}: ${kvp[1].length}`);
    for (let name of kvp[1]) {
      console.log(`--${name}`);
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Abbey Street, Herald Street, Bright Mews',
       'Bright Mews - Garry',
       'Bright Mews - Andrea',
       'Invalid Street - Tommy',
       'Abbey Street - Billy']);
