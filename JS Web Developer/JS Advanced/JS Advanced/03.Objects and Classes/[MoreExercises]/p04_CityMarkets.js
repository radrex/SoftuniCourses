function solve(input = []) {
  let markets = input.slice()
                     .map(x => x.split(' -> '))
                     .reduce((map, [town, productName, salesAndPricePerUnit]) => {
                       salesAndPricePerUnit = salesAndPricePerUnit.split(' : ');
                       let product = { 
                         name: productName,
                         sales: +salesAndPricePerUnit[0],
                         price: +salesAndPricePerUnit[1],
                       };
                     
                       if (!map.has(town)) {
                         map.set(town, [product]);
                         return map;
                       }
                     
                       let currentTown = map.get(town);
                       if (!currentTown.some(x => x.name === productName)) {
                         currentTown.push(product);
                         return map;
                       }
                     
                       let modifiedProduct = currentTown.find(x => x.name === productName);
                       modifiedProduct.sales += product.sales;
                       modifiedProduct.price = product.price;
                       return map;
                     }, new Map());

  return [...markets].map(([town, products]) => `Town - ${town}\n${products.map(x => `$$$${x.name} : ${x.sales * x.price}\n`).join('')}`).join('').trim();
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Sofia -> Laptops HP -> 200 : 2000',
                   'Sofia -> Raspberry -> 200000 : 1500',
                   'Sofia -> Audi Q7 -> 200 : 100000',
                   'Montana -> Portokals -> 200000 : 1',
                   'Montana -> Qgodas -> 20000 : 0.2',
                   'Montana -> Chereshas -> 1000 : 0.3']));
