function solve(words, template) {
  words = words.split(', ');
  while (words.length !== 0) {
    let word = words.shift();
    template = template.replace('*'.repeat(word.length), word);
  }

  console.log(template);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('great', 'softuni is ***** place for learning new programming languages');
solve('great, learning', 'softuni is ***** place for ******** new programming languages');
