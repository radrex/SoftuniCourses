function solve(arr = []) {
  let numberPlates = new Set();
  while (arr.length !== 0) {
    let [command, numberPlate] = arr.shift().split(', ');
    switch (command) {
      case 'IN':
        numberPlates.add(numberPlate);
        break;

      case 'OUT':
        numberPlates.delete(numberPlate);
        break;

      default:
        break;
    }
  }

  numberPlates.size !== 0 ? [...numberPlates].sort().forEach(x => console.log(x)) : console.log('Parking Lot is Empty');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['IN, CA2844AA',
       'IN, CA1234TA',
       'OUT, CA2844AA',
       'IN, CA9999TT',
       'IN, CA2866HI',
       'OUT, CA1234TA',
       'IN, CA2844AA',
       'OUT, CA2866HI',
       'IN, CA9876HH',
       'IN, CA2822UU']);

solve(['IN, CA2844AA',
       'IN, CA1234TA',
       'OUT, CA2844AA',
       'OUT, CA1234TA']);
