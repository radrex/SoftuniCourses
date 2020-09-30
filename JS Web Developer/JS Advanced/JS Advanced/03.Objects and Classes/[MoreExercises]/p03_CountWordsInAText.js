//------------------ DECLARATIVE APPROACH ------------------
function solve(arr = []) {
  return JSON.stringify(arr[0].match(/\w+/gim)
                              .reduce((acc, prop) => {
                                 addPropIfMissing(acc, prop);
                                 acc[prop]++;
                                 return acc;
                              }, {}));

  function addPropIfMissing(obj, prop) {
    if (typeof obj[prop] === "undefined") {
        obj[prop] = 0;
    }
    return obj;
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(["Far too slow, you're far too slow."]));
console.log(solve(["JS devs use Node.js for server-side JS.-- JS for devs"]))

//------------------ IMPERATIVE APPROACH ------------------
/*
  function solve(arr = []) {
      let data = arr[0].match(/\w+/gim);
      let obj = {};
      for (let i = 0; i < data.length; i++) {
          if (typeof obj[data[i]] === "undefined") {
              obj[data[i]] = 0;
          }
          obj[data[i]]++;
      }
      return JSON.stringify(obj);
  }

  // // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(["Far too slow, you're far too slow."]));
  console.log(solve(["JS devs use Node.js for server-side JS.-- JS for devs"]))
*/
