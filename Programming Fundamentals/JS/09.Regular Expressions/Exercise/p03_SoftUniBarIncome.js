function solve(input = []) {
  let customers = new Map();

  for (let i = 0; i < input.length; i++) {
    if (input[i] === 'end of shift') {
      break;
    }

    let matches = input[i].matchAll(/%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+\.?\d+)\$/);
    for (let match of matches) {
      let customer = match.groups['customer'];
      let product = match.groups['product'];
      let count = +match.groups['count'];
      let price = +match.groups['price'];

      product = { name: product, price: price * count };

      if (!customers.has(customer)) {
        customers.set(customer, [product]);
      } else {
        customers.get(customer).push(product);
      }
    }
  }

  let totalIncome = 0;
  for (let customer of customers) {
    for (let product of customer[1]) {
      totalIncome += product.price;
      console.log(`${customer[0]}: ${product.name} - ${product.price.toFixed(2)}`);
    }
  }

  console.log(`Total income: ${totalIncome.toFixed(2)}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['%George%<Croissant>|2|10.3$', '%Peter%<Gum>|1|1.3$', '%Maria%<Cola>|1|2.4$', 'end of shift']);
solve(['%InvalidName%<Croissant>|2|10.3$', '%Peter%<Gum>1.3$', '%Maria%<Cola>|1|2.4', '%Valid%<Valid>valid|10|valid20$', 'end of shift']);
