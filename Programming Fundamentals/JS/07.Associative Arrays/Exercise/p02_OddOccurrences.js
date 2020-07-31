function solve(words) {
  let map = new Map();
  words = words.split(' ').map(x => x.toLowerCase());
  
  for (let word of words) {
    if (!map.has(word)) {
      map.set(word, 1);
    } else {
      let count = map.get(word);
      map.set(word, count + 1);      
    }
  }
  
  map = new Map([...map].filter(x => x[1] % 2 !== 0));
  console.log([...map.keys()].join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
