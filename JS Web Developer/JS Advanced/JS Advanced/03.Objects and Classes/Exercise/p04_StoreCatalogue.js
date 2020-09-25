function solve(input = []) {
  let catalogue = input.slice()
                       .map(x => x.split(' : '))
                       .reduce((acc, [product, price]) => {
                         let key = product[0];
                         if (!acc.hasOwnProperty(key)) {
                           acc[key] = [{ product: product, price: price }];
                           return acc;
                         }
                       
                         acc[key].push({ product: product, price: price });
                         return acc;
                       }, {})

  catalogue = Object.entries(catalogue).sort((a, b) => a[0].localeCompare(b[0])).reduce((prev, current) => { prev[current[0]] = current[1]; return prev; }, {});
  for (let value of Object.values(catalogue)) {
    value = new Object(value.sort((a, b) => a.product.localeCompare(b.product)));
  }

  let output = '';
  for (let [key, value] of Object.entries(catalogue)) {
    output += `${key}\n`;
    for (let product of value) {
      output += ` ${product.product}: ${product.price}\n`;
    }
  }

  return output.trim();
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Appricot : 20.4',
                   'Fridge : 1500',
                   'TV : 1499',
                   'Deodorant : 10',
                   'Boiler : 300',
                   'Apple : 1.25',
                   'Anti-Bug Spray : 15',
                   'T-Shirt : 10']));

console.log(solve(['Banana : 2',
                   "Rubic's Cube : 5",
                   'Raspberry P : 4999',
                   'Rolex : 100000',
                   'Rollon : 10',
                   'Rali Car : 2000000',
                   'Pesho : 0.000001',
                   'Barrel : 10']));