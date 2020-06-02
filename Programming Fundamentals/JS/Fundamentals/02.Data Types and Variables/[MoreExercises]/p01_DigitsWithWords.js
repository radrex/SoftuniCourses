function solve(digit) {
  const digits = {
    'zero': 0,
    'one': 1,
    'two': 2,
    'three': 3,
    'four': 4,
    'five': 5,
    'six': 6,
    'seven': 7,
    'eight': 8,
    'nine': 9,
  };
  console.log(digits[digit]);

  //---- WITH SWITCH ----
  // let digitNum = undefined;
  // switch (digit) {
  //   case  'zero': digitNum = 0;   break;
  //   case  'one': digitNum = 1;    break;
  //   case  'two': digitNum = 2;    break;
  //   case  'three': digitNum = 3;  break;
  //   case  'four': digitNum = 4;   break;
  //   case  'five': digitNum = 5;   break;
  //   case  'six': digitNum = 6;    break;
  //   case  'seven': digitNum = 7;  break;
  //   case  'eight': digitNum = 8;  break;
  //   case  'nine': digitNum = 9;   break;
  //   default:
  //     break;
  // }
  // console.log(digitNum);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('nine');
solve('two');
solve('zero');
