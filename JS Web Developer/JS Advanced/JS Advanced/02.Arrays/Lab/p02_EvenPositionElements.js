function solve(numbers = []) {
  return numbers.filter((_, index) => index % 2 === 0).join(' ');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));

//------------- Different Approaches -------------
/*
  function solve(numbers = []) {
    let result = '';
    for (let i = 0; i < numbers.length; i += 2) {
      result += `${numbers[i]} `;
    }

    return result.trim();
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['20', '30', '40']));
  console.log(solve(['5', '10']));
*/

/*
  function solve(numbers = []) {
    let result = new Array(Math.floor(numbers.length / 2));
    for (let i = 0; i < numbers.length; i += 2) {
      result[i / 2] = numbers[i];
    }

    return result.join(' ');
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['20', '30', '40']));
  console.log(solve(['5', '10']));
*/
