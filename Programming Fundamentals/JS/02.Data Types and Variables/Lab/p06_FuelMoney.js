function solve(distance, passengers, price) {
  let requiredFuel = (distance / 100.0) * 7;
  requiredFuel += passengers * 0.100;
  let money = requiredFuel * price;
  console.log(`Needed money for that trip is ${money}lv.`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(260, 9, 2.49);
solve(90, 14, 2.88);
