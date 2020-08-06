function solve(text, word) {
  while (text.includes(word)) {
    text = text.replace(word, '*'.repeat(word.length));
  }

  console.log(text);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve("A small sentence with some words", "small");
