function solve(str) {
  let words = str.match(/#[A-Za-z]+/g).map(x => x.replace('#', ''));
  words.forEach(x => console.log(x));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
