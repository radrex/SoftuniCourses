function solve(str) {
  return str.match(/\w+/gim).map(x => x.toUpperCase()).join(", ");
}

console.log(solve('Hi, how are you?'));
console.log(solve('hello'));
