function solve(people, groupType, day) {
  let totalPrice = 0.0;
  switch (groupType) {
    case 'Students':
      switch (day) {
        case 'Friday':
          totalPrice += people * 8.45;
          if (people >= 30) {
            totalPrice *= 0.85;
          }
          break;
        case 'Saturday':
          totalPrice += people * 9.80;
          if (people >= 30) {
            totalPrice *= 0.85;
          }
          break;
        case 'Sunday':
          totalPrice += people * 10.46;
          if (people >= 30) {
            totalPrice *= 0.85;
          }
          break;
      }
      break;

    case 'Business':
      switch (day) {
        case 'Friday':
          totalPrice += people * 10.90;
          if (people >= 100) {
            totalPrice -= 10 * 10.90;
          }
          break;
        case 'Saturday':
          totalPrice += people * 15.60;
          if (people >= 100) {
            totalPrice -= 10 * 15.60;
          }
          break;
        case 'Sunday':
          totalPrice += people * 16;
          if (people >= 100) {
            totalPrice -= 10 * 16;
          }
          break;
      }
      break;

    case 'Regular':
      switch (day) {
        case 'Friday':
          totalPrice += people * 15;
          if (people >= 10 && people <= 20) {
            totalPrice *= 0.95;
          }
          break;
        case 'Saturday':
          totalPrice += people * 20;
          if (people >= 10 && people <= 20) {
            totalPrice *= 0.95;
          }
          break;
        case 'Sunday':
          totalPrice += people * 22.50;
          if (people >= 10 && people <= 20) {
            totalPrice *= 0.95;
          }
          break;
      }
      break;
  }

  console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(30, 'Students', 'Sunday');
solve(40, 'Regular', 'Saturday');
