function solve() {
  let types = {};
  for (let arg of arguments) {
    console.log(`${typeof arg}: ${arg}`);
    !types[typeof arg] ? types[typeof arg] = 1 : types[typeof arg]++;
  }

  Object.keys(types).sort((a, b) => types[b] - types[a]).forEach(x => console.log(`${x} = ${types[x]}`));
}

// Don't copy the code below in judge, you won't get any points, just the code above
solve('cat', 42, function () { console.log('Hello world!'); });
