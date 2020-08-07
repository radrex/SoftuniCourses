function solve(word, text) {
  word = word.toLowerCase();
  text = text.toLowerCase();

  console.log(text.split(" ").find(x => x === word) ? `${word}` : `${word} not found!`); 
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('javascript', 'JavaScript is the best programming language');
solve('python', 'JavaScript is the best programming language');