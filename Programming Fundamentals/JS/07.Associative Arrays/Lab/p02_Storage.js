function solve(arr = []) {
  let products = new Map();

  while (arr.length !== 0) {
    let [product, quantity] = arr.shift().split(' ');
    quantity = Number(quantity);

    if (!products.has(product)) {
      products.set(product, quantity);
    } else {
      let newQty = products.get(product) + quantity;
      products.set(product, newQty);
    }
  }

  for (let kvp of products) {
    console.log(`${kvp[0]} -> ${kvp[1]}`);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['tomatoes 10',
       'coffee 5',
       'olives 100',
       'coffee 40']);
