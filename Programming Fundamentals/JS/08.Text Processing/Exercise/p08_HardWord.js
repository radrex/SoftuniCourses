function solve(arr = []) {
  let sentence = arr[0];
  let words = arr[1];

  while (words.length !== 0) {
    let word = words.shift();

    for (let i = 0; i < sentence.length; i++) {
      let startIndex = -1;
      let counter = 0;

      if (sentence[i] === '_') {
        counter++;
        startIndex = i;
        while (sentence[++i] === '_') {
          counter++;
        }

        if (counter === word.length) {
          sentence = sentence.substring(0, startIndex) + word + sentence.substring(startIndex + word.length);
          i = 0;
        }
      }
    }
  }

  console.log(sentence);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Hi, grandma! I\'m so ____ to write to you. ______ the winter vacation, so _______ things happened. My dad bought me a sled. Mom started a new job as a __________. My brother\'s ankle is ________, and now it bothers me even more. Every night Mom cooks ___ on your recipe because it is the most delicious. I hope this year Santa will _____ me a robot.',
      ['pie', 'bring', 'glad', 'During', 'amazing', 'pharmacist', 'sprained']]);
