function arrayMap(arr, func) {
  return arr.reduce((acc, value) => {
    acc.push(func(value));
    return acc;
  }, []);
}

// Don't copy the code below in judge, you won't get any points, just the code above
let nums = [1,2,3,4,5];
console.log(arrayMap(nums,(item)=> item * 2)); // [ 2, 4, 6, 8, 10 ]

let letters = ["a","b","c"];
console.log(arrayMap(letters,(l)=>l.toLocaleUpperCase())) // [ 'A', 'B', 'C' ]
