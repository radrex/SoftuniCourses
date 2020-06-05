function solve(num) {
  let numAsText = num.toString();
  let lastDigit = (numAsText[numAsText.length - 1]);

  switch (lastDigit) {
    case '0':   console.log('zero');    break;
    case '1':   console.log('one');     break;
    case '2':   console.log('two');     break;
    case '3':   console.log('three');   break;
    case '4':   console.log('four');    break;
    case '5':   console.log('five');    break;
    case '6':   console.log('six');     break;
    case '7':   console.log('seven');   break;
    case '8':   console.log('eight');   break;
    case '9':   console.log('nine');    break;
  }

  //---- Differen Approach ----
  // const lastDigits = {
  //   '0': 'zero',
  //   '1': 'one',
  //   '2': 'two',
  //   '3': 'three',
  //   '4': 'four',
  //   '5': 'five',
  //   '6': 'six',
  //   '7': 'seven',
  //   '8': 'eight',
  //   '9': 'nine',
  // };
  // console.log(lastDigits[lastDigit]);

}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(512);
solve(1);
solve(1643);
