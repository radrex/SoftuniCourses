//@ts-check

//--------------- Declarative ---------------
function solve(str) {
    return str.match(/\w+/gim)
              .reduce((a, prop) => {
                  addPropIfMissing(a, prop);
                  a[prop]++;
                  return a;
              }, {});
}

function addPropIfMissing(a, b) {
    if (typeof a[b] === "undefined") {
        a[b] = 0;
    }
    return a;
}

console.log(solve("JS devs use Node.js for server-side JS.-- JS for devs"));

//--------------- Imperative ---------------
/*
    function solve(str) {
        let data = str.match(/\w+/gim);
        let obj = {};

        for (let i = 0; i < data.length; i++) {
            if (typeof obj[data[i]] === "undefined") {
                obj[data[i]] = 0;
            }
            obj[data[i]]++;
        }

        return obj;
    }

    console.log(solve("JS devs use Node.js for server-side JS.-- JS for devs"));
*/