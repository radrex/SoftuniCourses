function solution() {
  let str = '';
  return {
    append: (s) => str += s,
    removeStart: (n) => str = str.substring(n),
    removeEnd: (n) => str = str.substring(0, str.length - n),
    print: () => console.log(str),
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
