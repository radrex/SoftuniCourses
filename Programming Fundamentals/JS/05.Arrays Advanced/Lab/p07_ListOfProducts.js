function solve(products = []) {
  let counter = 1;
  products.sort().forEach(product => console.log(`${counter++}.${product}`));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(["Potatoes", "Tomatoes", "Onions", "Apples"]);
