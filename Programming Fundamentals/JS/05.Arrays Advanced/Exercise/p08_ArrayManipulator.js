function solve(arr = [], commands = []) {
  const add = (index, element) => {
    if (index < 0) {
      console.log(`Index out of bound.`);
      return;
    }

    for (let i = arr.length; i > index; i--) {
      arr[i] = arr[i - 1];
    }
    arr[index] = element;
  };

  const addMany = (index, ...elements) => {
    if (index < 0) {
      console.log(`Index out of bound.`);
      return;
    }

    elements = elements[0];
    
    for (let times = 0; times < elements.length; times++) {
      for (let i = arr.length; i > index; i--) {
        arr[i] = arr[i - 1];
      }
    }
    
    let counter = 0;
    for (let i = index; i < index + elements.length; i++) {
      arr[i] = elements[counter++];
    }
  };

  const contains = element => {
    for (let i = 0; i < arr.length; i++) {
      if (arr[i] === element) {
        return i;
      }
    }

    return -1;
  };

  const remove = index => {
    if (index < 0 || index > arr.length - 1) {
      console.log(`Index out of bound.`);
    }

    for (let i = index; i < arr.length - 1; i++) {
      arr[i] = arr[i + 1];
    }

    arr.length--;
  };

  const shift = positions => {
    while (positions-- > 0) {
      let firstNumber = arr[0];
      for (let i = 0; i < arr.length - 1; i++) {
        arr[i] = arr[i + 1];
      }
  
      arr[arr.length - 1] = firstNumber;
    }
  };

  const sumPairs = () => {
    let iterations = Math.ceil(arr.length / 2);

    for (let i = 0, index = 0; i < iterations; i++, index += 2) {
      arr[i] = (arr.length - 1 === index) ? arr[index] : arr[index] + arr[index + 1];
    }

    arr.length = iterations;
  };

  while (commands.length !== 0) {
    let command = commands.shift().split(' ');

    switch (command.shift()) {
      case 'add':       add(+command[0], +command[1]);                    break;
      case 'addMany':   addMany(+command.shift(), command.map(x => +x));  break;
      case 'contains':  console.log(contains(+command[0]));               break;
      case 'remove':    remove(+command[0]);                              break;
      case 'shift':     shift(+command[0]);                               break;
      case 'sumPairs':  sumPairs();                                       break;
      case 'print':     console.log(`[ ${arr.join(', ')} ]`);             break;

      default:
        break;
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([1, 2, 4, 5, 6, 7], ['add 1 8', 'contains 1', 'contains 3', 'print']);
solve([1, 2, 3, 4, 5], ['addMany 5 9 8 7 6 5', 'contains 15', 'remove 3', 'shift 1', 'print']);
solve([1, 2, 4, 5, 6, 7, 8], ['sumPairs', 'print']);
solve([1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2], ["sumPairs", "sumPairs", "addMany 0 -1 -2 -3", "print"]);