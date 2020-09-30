class Kitchen {
  constructor(budget) {
    this.budget = budget;
    this.menu = {};
    this.productsInStock = {};
    this.actionsHistory = [];
  }

  loadProducts(products = []) {
    products.map(x => x.split(' '))
            .forEach(([name, quantity, price]) => {
              quantity = +quantity;
              price = +price;

              if (this.budget >= price) {
                if (!this.productsInStock.hasOwnProperty(name)) {
                  this.productsInStock[name] = 0;
                }
                this.productsInStock[name] += quantity;
                this.budget -= price;
                
                this.actionsHistory.push(`Successfully loaded ${quantity} ${name}`);
              } else {
                this.actionsHistory.push(`There was not enough money to load ${quantity} ${name}`);
              }
            });

    return this.actionsHistory.join('\n');
  }

  addToMenu(meal, neededProducts = [], price) {
    if (!this.menu.hasOwnProperty(meal)) {
      this.menu[meal] = { products: neededProducts, price: +price };
      return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
    }

    return `The ${meal} is already in our menu, try something different.`;
  }

  showTheMenu() {
    let output = '';
    Object.entries(this.menu).forEach(x => output += `${x[0]} - $ ${x[1].price}\n`);

    if (output.length === 0) {
      return `Our menu is not ready yet, please come later...`;
    }

    return output;
  }

  makeTheOrder(meal) {
    if (!this.menu.hasOwnProperty(meal)) {
      return `There is not ${meal} yet in our menu, do you want to order something else?`;
    }

    let requiredProducts = this.menu[meal].products;
    if (!requiredProducts.every(x => { let [product, quantity] = x.split(' '); return this.productsInStock[product] >= +quantity; })) {
      return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
    }

    this.budget += this.menu[meal].price;
    requiredProducts.forEach(x => { let [product, quantity] = x.split(' '); this.productsInStock[product] -= quantity});

    return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
  }
}

// Don't copy the code below in judge, you won't get any points, just the code above
let kitchen = new Kitchen(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log(kitchen.showTheMenu());
console.log(kitchen.makeTheOrder('frozenYogurt'));
