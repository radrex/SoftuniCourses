function solve(arr) {
  const coffeeTypes = {
    caffeine: 0.8,
    decaf: 0.9,
  }

  let totalIncome = 0;

  for (let currentOrder of arr) {
    let order = currentOrder.split(", ");

    let coins = +order[0];
    let drink = order[1];
    let price = 0;

    if (drink === "coffee") {
      price += coffeeTypes[order[2]];
    } else {
      price = 0.8; 
    }

    if (order.includes("milk")) {
      price = +(price * 1.1).toFixed(1);
    }

    let sugar = +order.pop();

    if (sugar) {
      price += 0.1;
    }

    printOrder(coins, price, drink);
  }

  console.log(`Income Report: $${totalIncome.toFixed(2)}`);

  function printOrder(coins, price, drink) {
    if (coins >= price) {
      totalIncome += price;
      console.log(`You ordered ${drink}. Price: $${price.toFixed(2)} Change: $${(coins - price).toFixed(2)}`);
    } else {
      console.log(`Not enough money for ${drink}. Need $${(price - coins).toFixed(2)} more.`);
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);
solve(['8.00, coffee, decaf, 4', '1.00, tea, 2']);
