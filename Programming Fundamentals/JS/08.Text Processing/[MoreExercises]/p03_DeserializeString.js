function solve(arr = []) {
  let deserializedString = [];
  for (let i = 0; i < arr.length; i++) {
    if (arr[i] !== 'end') {
      let indexes = arr[i].split(/:|\//);
      let letter = indexes.shift();
      indexes.forEach(x => deserializedString[x] = letter);
    }
  }

  console.log(deserializedString.join(''))
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['a:0/2/4/6', 'b:1/3/5', 'end']);
solve(['a:0/3/5/11', 'v:1/4', 'j:2', 'm:6/9/15', 's:7/13', 'd:8/14', 'c:10', 'l:12', 'end']);
