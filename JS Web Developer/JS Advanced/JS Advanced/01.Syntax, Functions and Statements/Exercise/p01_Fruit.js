function solve(fruit, weight, price) {
  let money = (weight * price) / 1000;
  console.log(`I need $${money.toFixed(2)} to buy ${(weight / 1000).toFixed(2)} kilograms ${fruit}.`)
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('orange', 2500, 1.80);
solve('apple', 1563, 2.35);
