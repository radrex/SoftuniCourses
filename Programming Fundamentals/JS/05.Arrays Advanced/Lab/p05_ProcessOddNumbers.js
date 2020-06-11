function solve(arr = []) {
  let extractedNums = arr.filter((num, i) => i % 2 == 1)
                         .map(x => x * 2)
                         .reverse();

  console.log(extractedNums.join(' '));

  //---- Different Approach ----
  // let extractedNums = [];
  // for (let i = 0; i < arr.length; i++) {
  //   if (i % 2 !== 0) {
  //     extractedNums.push(arr[i] * 2);
  //   }
  // }
  // console.log(extractedNums.reverse().join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([10, 15, 20, 25]);
solve([3, 0, 10, 4, 7, 3]);