function solve(arr1 = [], arr2 = []) {
  let commonElements = [];

  for (let arr1Element of arr1) {
    for (let arr2Element of arr2) {
      if (arr1Element === arr2Element && !commonElements.includes(arr1Element)) {
        commonElements.push(arr1Element);
      }
    }
  }

  console.log(commonElements.join('\n'));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Hey', 'hello', 2, 4, 'Peter', 'e'], ['Petar', 10, 'hey', 4, 'hello', '2']);
solve(['S', 'o', 'f', 't', 'U', 'n', 'i', ' '], ['s', 'o', 'c', 'i', 'a', 'l']);
