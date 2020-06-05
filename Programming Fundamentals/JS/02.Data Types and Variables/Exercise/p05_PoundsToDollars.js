function poundsToDollars(pounds) {
  const exchangeRate = 1.31;
  let dollars = pounds * exchangeRate;
  return dollars.toFixed(3);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(poundsToDollars(80));
console.log(poundsToDollars(39));
