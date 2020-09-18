//------------------ IMPERATIVE APPROACH ------------------
function solve(input = []) {
  let products = new Map();
  for (let productData of input) {
      let [town, product, price] = productData.split(" | ");
      if (!products.has(product)) {
          products.set(product, new Map());
      }
      products.get(product).set(town, +price);
  }

  let output = '';
  for (let [key, value] of products) {
    let [town, price] = [...value].reduce((acc, value) => {
        if (acc[1] > value[1]) {
          return value;
        }

        return acc;
    });
    output += `${key} -> ${price} (${town})\n`;
  }

  return output.trim();
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Sample Town | Sample Product | 1000',
                   'Sample Town | Orange | 2',
                   'Sample Town | Peach | 1',
                   'Sofia | Orange | 3',
                   'Sofia | Peach | 2',
                   'New York | Sample Product | 1000.1',
                   'New York | Burger | 10']));

console.log(solve(['Sofia City | Audi | 100000',
                   'Sofia City | BMW | 100000',
                   'Sofia City | Mitsubishi | 10000',
                   'Sofia City | Mercedes | 10000',
                   'Sofia City | NoOffenseToCarLovers | 0',
                   'Mexico City | Audi | 1000',
                   'Mexico City | BMW | 99999',
                   'New York City | Mitsubishi | 10000',
                   'New York City | Mitsubishi | 1000',
                   'Mexico City | Audi | 100000',
                   'Washington City | Mercedes | 1000']));
