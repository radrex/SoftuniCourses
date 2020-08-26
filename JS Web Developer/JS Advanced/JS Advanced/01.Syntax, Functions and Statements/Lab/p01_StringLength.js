function solve(x, y, z) {
  let sum = x.length + y.length + z.length;
  let avrg = Math.floor(sum/3);
  console.log(sum);
  console.log(avrg)
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('chocolate', 'ice cream', 'cake');

//---------------- Generic Solution -----------------
/*
    function solve(...params) {
      let sum = params.reduce((a, b) => a + b.length, 0);
      let avrg = Math.floor(sum / params.length);

      return[sum, avrg];
    }

    console.log(
      solve('chocolate', 'ice cream', 'cake').join("\n")
    );

    console.log(
      solve('chocolate', 'ice cream', 'cake', 'biscuit', 'topping').join("\n")
    );
*/