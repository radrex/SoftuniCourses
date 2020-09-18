//------------------ IMPERATIVE APPROACH ------------------
function solve(arr = []) {
  let result = {};
  for (let i = 0; i < arr.length; i++) {
    let [town, population] = arr[i].split(' <-> ');
    if (!result.hasOwnProperty(town)) {
      result[town] = +population;
      continue;
    }

    result[town] += +population;
  }

  let output = '';
  Object.entries(result).forEach(x => output += `${x[0]} : ${x[1]}\n`);
  return output.trim();
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Sofia <-> 1200000',
                   'Montana <-> 20000',
                   'New York <-> 10000000',
                   'Washington <-> 2345000',
                   'Las Vegas <-> 1000000']));

console.log(solve(['Istanbul <-> 100000',
                   'Honk Kong <-> 2100004',
                   'Jerusalem <-> 2352344',
                   'Mexico City <-> 23401925',
                   'Istanbul <-> 1000']));

//------------------ DECLARATIVE APPROACH ------------------ I ----
/*
  function solve(arr = []) {
    return Object.entries(arr.slice()
                            .map(x => x.split(' <-> '))
                            .reduce((acc, value) => {
                              if (!acc.hasOwnProperty(value[0])) {
                                acc[value[0]] = +value[1];
                                return acc;
                              }
                            
                              acc[value[0]] += +value[1]
                              return acc;
                            }, {})
                          )
                          .map(x => `${x[0]} : ${x[1]}`)
                          .join('\n');
  }            

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['Sofia <-> 1200000',
                    'Montana <-> 20000',
                    'New York <-> 10000000',
                    'Washington <-> 2345000',
                    'Las Vegas <-> 1000000']));

  console.log(solve(['Istanbul <-> 100000',
                    'Honk Kong <-> 2100004',
                    'Jerusalem <-> 2352344',
                    'Mexico City <-> 23401925',
                    'Istanbul <-> 1000']));
*/

//------------------ DECLARATIVE APPROACH ------------------ II ----
/*
  function solve(arr = []) {
    const actions = {
      true: function create(obj, value) {
        obj[value[0]] = +value[1];
        return obj;
      },
      false: function add(obj, value) {
        obj[value[0]] += +value[1];
        return obj;
      },
    };

    return Object.entries(arr.slice()
                            .map(x => x.split(' <-> '))
                            .reduce((acc, value) => actions[!acc.hasOwnProperty(value[0])](acc, value), {})
                          )
                          .map(x => `${x[0]} : ${x[1]}`)
                          .join('\n');
  }            

  // // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['Sofia <-> 1200000',
                    'Montana <-> 20000',
                    'New York <-> 10000000',
                    'Washington <-> 2345000',
                    'Las Vegas <-> 1000000']));

  console.log(solve(['Istanbul <-> 100000',
                    'Honk Kong <-> 2100004',
                    'Jerusalem <-> 2352344',
                    'Mexico City <-> 23401925',
                    'Istanbul <-> 1000']));
*/
