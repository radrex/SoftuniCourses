//---------------- WITH MAP (working in judge) ----------------
function catalog(arr = []) {
  let products = new Map();
  for (let i = 0; i < arr.length; i++) {
    let [product, price] = arr[i].split(' : ');
    let key = product.charAt(0);
    product = { 
      name: product, 
      price: Number(price),
    }

    if (!products.has(key)) {
      products.set(key, [product]);
    } else {
      products.get(key).push(product);
    }
  }

  products = new Map([...products.entries()].sort()); // SORT KEYS FIRST ('B', 'C', 'A' --> 'A', 'B', 'C')
  for (let key of products.keys()) {
    products.get(key).sort((a, b) => a.name.localeCompare(b.name)); // SORT PRODUCTS BY NAME FOR EACH KEY
    // products.get(key).sort((a, b) => a.name > b.name ? 1 : -1);
  }

  for (let [key, value] of products) {
    console.log(key);
    for (let product of value) {
      console.log(`  ${product.name}: ${product.price}`)
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
catalog(['Appricot : 20.4',
         'Fridge : 1500',
         'TV : 1499',
         'Deodorant : 10',
         'Boiler : 300',
         'Apple : 1.25',
         'Anti-Bug Spray : 15',
         'T-Shirt : 10']);

//---------------- WITH OBJECT (WITHOUT MAP) (working in judge) ----------------
// function catalog(arr = []) {
//   let products = {};
//   for (let i = 0; i < arr.length; i++) {
//     let [product, price] = arr[i].split(' : ');
//     addProduct(product, Number(price));
//   }

//   sort();
//   print();

//   //---------- FUNCTIONS ----------
//   function addProduct(product, price) {
//     let key = product.charAt(0);
//     product = { 
//       name: product, 
//       price: price,
//     }

//     if (!products.hasOwnProperty(key)) {
//       products[key] = [];
//       products[key].push(product);
//     } else {
//       products[key].push(product);
//     }
//   }

//   function sort() {
//     products = Object.fromEntries(Object.entries(products).sort());
//     let keys = Object.keys(products);
//     for (const key of keys) {
//       products[key].sort((a, b) => a.name.localeCompare(b.name));
//       // products[key].sort((a, b) => a.name > b.name ? 1 : -1);
//     }
//   }

//   function print() {
//     for (let key in products) {
//       console.log(key);
//       for (let product of products[key]) {
//         console.log(`  ${product.name}: ${product.price}`)
//       }
//     }
//   }
// }

// // Don't copy the calling of the function in judge, you won't get any points, just the code above
// catalog(['Appricot : 20.4',
//          'Fridge : 1500',
//          'TV : 1499',
//          'Deodorant : 10',
//          'Boiler : 300',
//          'Apple : 1.25',
//          'Anti-Bug Spray : 15',
//          'T-Shirt : 10']);


//---------------- USING A CLASS WITH OBJECT (WITHOUT MAP) (not working in judge) ----------------
// class Catalog {
//   constructor(arr = []){
//     this.products = {};
//     for (let i = 0; i < arr.length; i++) {
//       let [product, price] = arr[i].split(' : ');
//       this.addProduct(product, Number(price));
//     }
//   }

//   addProduct(product, price) {
//     let key = product.charAt(0);
//     product = { 
//       name: product, 
//       price: price,
//     }

//     if (!this.products.hasOwnProperty(key)) {
//       this.products[key] = [];
//       this.products[key].push(product);
//     } else {
//       this.products[key].push(product);
//     }
//   }

//   sort() {
//     this.products = Object.fromEntries(Object.entries(this.products).sort());
//     let keys = Object.keys(this.products);
//     for (const key of keys) {
//       this.products[key].sort((a, b) => a.name.localeCompare(b.name));
//       // this.products[key].sort((a, b) => a.name > b.name ? 1 : -1);
//     }
//   }

//   print() {
//     for (let key in this.products) {
//       console.log(key);
//       for (let product of this.products[key]) {
//         console.log(`  ${product.name}: ${product.price}`)
//       }
//     }
//   }
// }

// let catalog = new Catalog(['Appricot : 20.4',
//                            'Fridge : 1500',
//                            'TV : 1499',
//                            'Deodorant : 10',
//                            'Boiler : 300',
//                            'Apple : 1.25',
//                            'Anti-Bug Spray : 15',
//                            'T-Shirt : 10']);
// catalog.sort();
// catalog.print();
