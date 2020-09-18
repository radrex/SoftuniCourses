//------------------ IMPERATIVE APPROACH ------------------
function solve(arr = []) {
  let result = {};
  for (let i = 0; i < arr.length; i += 2) {
    if (!result.hasOwnProperty(arr[i])) {
      result[arr[i]] = +arr[i + 1];
      continue;
    }

    result[arr[i]] += +arr[i + 1];
  }

  return JSON.stringify(result);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Sofia','20','Varna','3','Sofia','5','Varna','4']));
console.log(solve(['Sofia','20','Varna','3','sofia','5','varna','4']));

//------------------ DECLARATIVE APPROACH ------------------ I ----
/*
  function solve(input = []) {
    const actions = {
      true: function add(obj, x, y) { 
        obj[x] += y;
        return obj;
      },

      false: function create(obj, x, y) { 
        obj[x] = y;
        return obj;
      },
    }

    let result = input.slice()
                      .reduce((acc, value, i, arr) => {
                        if (i % 2 === 0) {
                          return actions[acc.hasOwnProperty(value)](acc, value, +(arr[i + 1]))
                        }
                      
                        return acc;
                      }, {});

    return JSON.stringify(result);
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['Sofia','20','Varna','3','Sofia','5','Varna','4']));
  console.log(solve(['Sofia','20','Varna','3','sofia','5','varna','4']));
*/

//------------------ DECLARATIVE APPROACH ------------------ II ----
/*
  function solve(input = []) {
    let result = input.slice()
                      .reduce((acc, value, i, arr) => {
                        if (i % 2 === 0) {
                          if (acc.hasOwnProperty(value)) {
                            acc[value] += Number(arr[i + 1]);
                            return acc;
                          }

                          acc[value] = Number(arr[i + 1]);
                          return acc;
                        }
                      
                        return acc;
                      }, {});

    return JSON.stringify(result);
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['Sofia','20','Varna','3','Sofia','5','Varna','4']));
  console.log(solve(['Sofia','20','Varna','3','sofia','5','varna','4']));
*/
