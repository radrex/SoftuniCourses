function solve(arr = []) {
  for (let i = 1; i < arr.length; i++) {
    let keys = arr[0].split(' ').map(x => +x);

    if (arr[i] === 'find') {
       break;
    }

    let message = [...arr[i]];
    for (let j = 0; j < message.length; j++) {
      let decrementator = keys.shift();
      keys.push(decrementator);

      message[j] = message[j].charCodeAt(0) - decrementator;
    }

    message = String.fromCharCode(...message);

    let type = message.match(/&[\S\s]+&/)[0].replace(new RegExp('&', 'g'), '');
    let coordinates = message.match(/<[[\S\s]+>/)[0].replace(new RegExp('<|>', 'g'), '');
    console.log(`Found ${type} at ${coordinates}`);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['1 2 1 3', "ikegfp'jpne)bv=41P83X@", "ujfufKt)Tkmyft'duEprsfjqbvfv=53V55XA", 'find']);
