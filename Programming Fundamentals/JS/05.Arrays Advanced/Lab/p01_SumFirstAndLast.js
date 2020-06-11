function sumFirstAndLast(arr = []) {
  arr = arr.map(x => +x);
  return arr.shift() + arr.pop();
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(sumFirstAndLast(['20', '30', '40']));
console.log(sumFirstAndLast(['5', '10']));
