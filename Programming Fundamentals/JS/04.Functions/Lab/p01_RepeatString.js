function repeatString(string, repeatCount) {
  let result = '';
  while (repeatCount-- > 0) {
    result += string;
  }

  return result;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(repeatString('abc', 3));
console.log(repeatString('String', 2));
