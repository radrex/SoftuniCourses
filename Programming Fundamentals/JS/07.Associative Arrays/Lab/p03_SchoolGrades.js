function solve(arr = []) {
  let map = new Map();

  for (let str of arr) {
    let tokens = str.split(' ');
    let name = tokens[0];
    let grades = tokens.splice(1, tokens.length).map(Number);

    if (!map.has(name)) {
      map.set(name, grades);
    } else {
      map.set(name, map.get(name).concat(grades));
    }
  }

  map = Array.from(map).sort((a, b) => (a[1].reduce((acc, value) => acc + value) / a[1].length) - (b[1].reduce((acc, value) => acc + value) / b[1].length));
  
  for (let kvp of map) {
    console.log(`${kvp[0]}: ${kvp[1].join(', ')}`);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Lilly 4 6 6 5',
       'Tim 5 6',
       'Tammy 2 4 3',
       'Tim 6 6']);
