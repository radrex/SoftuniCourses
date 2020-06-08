function totalPrice(product, quantity) {
  const menu = {
    'coffee' : price => quantity * 1.50,
    'water' : price => quantity * 1.00,
    'coke' : price => quantity * 1.40,
    'snacks' : price => quantity * 2.00,
  }

  return menu[product](quantity).toFixed(2);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(totalPrice('water', 5));
console.log(totalPrice('coffee', 2));
