function solve(arr = []) {
  let words = {};

  for (let word of arr.shift().split(' ')) {
    words[word] = 0;
  }

  for (let word of arr) {
    if (words.hasOwnProperty(word)) {
      words[word]++;
    }
  }

  words = Object.entries(words).sort((a, b) => b[1] - a[1]).reduce((prev, current) => { prev[current[0]] = current[1]; return prev; }, {});
  // words = Object.fromEntries(Object.entries(words).sort((a, b) => b[1] - a[1])); 2nd WAY

  for (const word in words) {
    console.log(`${word} - ${words[word]}`);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['this sentence', 'In','this','sentence','you','have','to','count','the','occurances','of','the','words','this','and','sentence','because','this','is','your','task']);
