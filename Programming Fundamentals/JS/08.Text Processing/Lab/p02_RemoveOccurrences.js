function solve(word, text) {
  while (text.includes(word)) {
    text = text.replace(word, '');
  }
  console.log(text);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('ice', 'kicegiciceeb');
