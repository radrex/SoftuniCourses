function solve(data) {
  let keys = deserialize(data[0]);
  return JSON.stringify(data.slice(1)
                            .map(deserialize)
                            .map(x => x.reduce((acc, value, i) => {
                                acc[keys[i]] = value;
                                return acc;
                            }, {}))); 
                          
  function deserialize(str) {
    const isNotEmptyString = x => x !== ""; // Predicates
    const trimMyStrings = x => x.trim();
    const parseIfNumber = x => isNaN(+x) ? x : Number(Number(x).toFixed(2));

    return str.split("|")
              .filter(isNotEmptyString)
              .map(trimMyStrings)
              .map(parseIfNumber);
  }           
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['| Town | Latitude | Longitude |',
                   '| Sofia | 42.696552 | 23.32601 |',
                   '| Beijing | 39.913818 | 116.363625 |']));

console.log(solve(['| Town | Latitude | Longitude |',
                   '| Veliko Turnovo | 43.0757 | 25.6172 |',
                   '| Monatevideo | 34.50 | 56.11 |']));

console.log(solve(['| Town | Latitude | Longitude |',
                   '| Random Town | 0.00 | 0.00 |']))