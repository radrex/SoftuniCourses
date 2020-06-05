function solve(arr = []) {
  let numbers = [];
  let increment = 0;

  for (let command of arr) {
    switch (command) {
      case 'add':
        increment++;
        numbers.push(increment);
        break;
      case 'remove':
        increment++;
        numbers.pop(numbers[numbers.length - 1]);
        break;
    }
  }

  console.log(numbers.length === 0 ? 'Empty' : numbers.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['add', 'add', 'add', 'add']);
solve(['add', 'add', 'remove', 'add', 'add']);
solve(['remove', 'remove', 'remove']);
