function solve(tokens) {
  const goldPrice = 67.51;
  const bitcoinPrice = 11949.16;

  let money = 0.0;
  let bitcoins = 0;
  let dayOfFirstPurchasedBitcoin; // undefined

  for (let i = 1; i <= tokens.length; i++) {
    let gold = parseFloat(tokens[i - 1]);
    if (i % 3 === 0) {
      gold *= 0.7;
    }
    money += gold * goldPrice;
    
    while (money >= bitcoinPrice) {
      money -= bitcoinPrice;
      bitcoins++;
      if (dayOfFirstPurchasedBitcoin === undefined) {
        dayOfFirstPurchasedBitcoin = i;
      }
    }
  }

  console.log(`Bought bitcoins: ${bitcoins}`);
  if (dayOfFirstPurchasedBitcoin !== undefined) {
    console.log(`Day of the first purchased bitcoin: ${dayOfFirstPurchasedBitcoin}`);
  }
  console.log(`Left money: ${money.toFixed(2)} lv.`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([100,200,300]);
solve([50, 100]);
solve([3124.15, 504.212, 2511.124]);
