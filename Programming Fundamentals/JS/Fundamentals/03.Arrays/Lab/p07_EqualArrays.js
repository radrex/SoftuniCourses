function solve(arr1, arr2) {
  let sum = 0;
  for (let i in arr1) {
      if (arr1[i] !== arr2[i]) {
          console.log(`Arrays are not identical. Found difference at ${i} index`);
          return;
      }
      sum += arr1[i] - 0; //ASCII hack
  }

  console.log(`Arrays are identical. Sum: ${sum}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['10', '20', '30'], ['10', '20', '30']);
solve(['1', '2', '3', '4', '5'], ['1', '2', '4', '4', '5']);
solve(['1'], ['10']);
