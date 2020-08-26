function solve(str) {
  return str.match(/\w+/gim).map(x => x.toUpperCase()).join(", ");
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve('Hi, how are you?'));
console.log(solve('hello'));
