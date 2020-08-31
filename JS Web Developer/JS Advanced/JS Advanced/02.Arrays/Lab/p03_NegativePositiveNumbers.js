//------------------ IMPERATIVE APPROACH ------------------
function solve(numbers = []) {
  let result = [];

  for (let i = 0; i < numbers.length; i++) {
    numbers[i] < 0 ? result.unshift(numbers[i]) : result.push(numbers[i]);
  }

  return result.join('\n');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve([7, -2, 8, 9]));
console.log(solve([3, -2, 0, -1]));


//------------------ IMPERATIVE / DECLARATIVE APPROACH ------------------ I ----
/*
  function solve(numbers = []) {
    const actions = {
      true: 'unshift',
      false: 'push'
    }

    let result = [];
    for (let i = 0; i < numbers.length; i++) {
      result[actions[numbers[i] < 0]](numbers[i]); // Because arrays are objects we can use their properties with [ ] or . --> result['unshift / push'](numbers[i])
    }                                              //                                                                      --> result.unshift(numbers[i])
                                                   //                                                                      --> result.push(numbers[i])                                                
    return result.join('\n');
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve([7, -2, 8, 9]));
  console.log(solve([3, -2, 0, -1]));
*/

//------------------ DECLARATIVE APPROACH ------------------ I ----
/*
  function solve(numbers = []) {
    const actions = {
      true: 'unshift',
      false: 'push'
    };

    return numbers.reduce((acc, value) => {
      acc[actions[value < 0]](value);
      return acc;
    }, []).join('\n');
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve([7, -2, 8, 9]));
  console.log(solve([3, -2, 0, -1]));
*/

//------------------ DECLARATIVE APPROACH ------------------ II ----
/*
  function solve(numbers = []) {
    const actions = {
      true: 'unshift',
      false: 'push'
    };

    return numbers.reduce((acc, value) => acc[actions[value < 0]](value) && acc, []).join('\n');
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve([7, -2, 8, 9]));
  console.log(solve([3, -2, 0, -1]));
*/
