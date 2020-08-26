function solve(arr) {
  let obj = new Object();

  for (let i = 0; i < arr.length; i+=2) {
    let key = arr[i];
    let value = +arr[i + 1];

    obj[key] = value;
  }

  console.log(obj);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Yoghurt', 48, 'Rise', 138, 'Apple', 52]);
solve(['Potato', 93, 'Skyr', 63, 'Cucumber', 18, 'Milk', 42]);