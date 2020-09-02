//------------------ IMPERATIVE APPROACH ------------------
function solve(input = []) {
  let arr = input.slice();
  let counter = 1;

  let result = [];
  for (let i = 0; i < arr.length; i++) {
    switch (arr[i]) {
      case 'add':
        result.push(counter);
        counter++;
        break;
    
      case 'remove':
        result.pop();
        counter++;
        break;

      default:
        break;
    }
  }

  return result.length === 0 ? 'Empty' : result.join('\n');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['add', 'add', 'add', 'add']));
console.log(solve(['add', 'add', 'remove', 'add', 'add']));
console.log(solve(['remove', 'remove', 'remove']));

//------------------ DECLARATIVE APPROACH ------------------ I ----
/*
  function solve(input = []) {
    let arr = input.slice();
    let counter = 1;
    let result = [];

    const actions = {
      'add': 'push',
      'remove': 'pop'
    };

    arr.reduce((acc, value) => result[actions[value]](counter++), []);
    return result.length === 0 ? 'Empty' : result.join('\n');
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['add', 'add', 'add', 'add']));
  console.log(solve(['add', 'add', 'remove', 'add', 'add']));
  console.log(solve(['remove', 'remove', 'remove']));
*/

//------------------ DECLARATIVE APPROACH ------------------ II ----
/*
  function solve(input = []) {
    let arr = input.slice();
    let counter = 1;

    const actions = {
      'add': 'push',
      'remove': 'pop'
    };

    let result = arr.reduce((acc, action) => { 
      acc[actions[action]](counter++);
      return acc;
    }, []);
    return result.length === 0 ? 'Empty' : result.join('\n');
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['add', 'add', 'add', 'add']));
  console.log(solve(['add', 'add', 'remove', 'add', 'add']));
  console.log(solve(['remove', 'remove', 'remove']));
*/
