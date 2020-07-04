function solve(stockTokens = [], productTokens = []) {
  let products = [];

  while (stockTokens.length !== 0) {
    let productName = stockTokens.shift();
    let productQty = Number(stockTokens.shift());

    let product = createProduct(productName, productQty);
    products.push(product);
  }

  while (productTokens.length !== 0) {
    let productName = productTokens.shift();
    let productQty = Number(productTokens.shift());

    let product = products.find(x => x.name === productName);

    if (product === undefined) {
      product = createProduct(productName, productQty);
      products.push(product);
    } else {
      product.quantity += productQty;
    }
  }

  products.forEach(x => console.log(`${x.name} -> ${x.quantity}`));

  function createProduct(name, quantity) { return product = { name, quantity }; }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
      ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']);
