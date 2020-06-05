function solve(input) {
  console.log(input.split('').reverse().join(''))

  //---- Different Approach ----
  // let reversed = '';
  // for (let i = input.length - 1; i >= 0; i--) {
  //   reversed += input[i];
  // }
  // console.log(reversed);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('Hello');
solve('SoftUni');
solve('1234');
