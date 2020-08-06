function solve(text, word) {
  console.log(text.split(' ').filter(x => x === word).length);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve("This is a word and it also is a sentence", "is");
