function solve(string) {
  string = string[0];
  let serializator = new Map();

  for (let i = 0; i < string.length; i++) {
    if (!serializator.has(string[i])) {
      serializator.set(string[i], [i]);
    } else {
      serializator.get(string[i]).push(i);
    }
  }

  for (let [key, value] of serializator) {
    console.log(`${key}:${value.join('/')}`)
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['abababa']);
solve(['avjavamsdmcalsdm']);
