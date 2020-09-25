function solve(input = []) {
  const bottles = new Map();
 
  input.reduce((acc, value) => {
    let [juice, quantity] = value.split(" => ");
    quantity = +quantity;
 
    if(!acc.hasOwnProperty(juice)) {
        acc[juice] = 0;
    }  
    acc[juice] += quantity;
 
    if (acc[juice] >= 1000) {
      if (!bottles.has(juice)) {
        bottles.set(juice, 0);
      }
 
    bottles.set(juice, bottles.get(juice) + parseInt(acc[juice] / 1000));
      acc[juice] %= 1000;
    }
 
    return acc;
  }, {});
 
  let output = '';
  for(let[juice, quantity] of bottles) {
    output += `${juice} => ${quantity}\n`;
  }

  return output.trim();
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Orange => 2000',
                   'Peach => 1432',
                   'Banana => 450',
                   'Peach => 600',
                   'Strawberry => 549']));

console.log(solve(['Kiwi => 234',
                   'Pear => 2345',
                   'Watermelon => 3456',
                   'Kiwi => 4567',
                   'Pear => 5678',
                   'Watermelon => 6789']));