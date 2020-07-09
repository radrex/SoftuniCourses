function solve(arr = []) {
  let words = new Map();
  while (arr.length !== 0) {
    let word = arr.shift();
    if (!words.has(word)) {
      words.set(word, 1);
    } else {
      words.set(word, words.get(word) + 1);
    }
  }

  words = [...words].sort((a, b) => b[1] - a[1]);

  for (let kvp of words) {
    console.log(`${kvp[0]} -> ${kvp[1]} times`);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(["Here", "is", "the", "first", "sentence", "Here", "is", "another", "sentence", "And", "finally", "the", "third", "sentence"]);
