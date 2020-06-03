function solve(arr1 = [], arr2 = []) {
  let mergedArr = [];
  for (let i = 0; i < arr1.length; i++) {
    i % 2 === 0 ? mergedArr.push(+arr1[i] + +arr2[i]) : mergedArr.push(arr1[i] + arr2[i]);
  }

  console.log(mergedArr.join(' - '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['5', '15', '23', '56', '35'], ['17', '22', '87', '36', '11']);
solve(['13', '12312', '5', '77', '4'], ['22', '333', '5', '122', '44']);
