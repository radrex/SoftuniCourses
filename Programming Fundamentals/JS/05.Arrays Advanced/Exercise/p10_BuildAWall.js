function solve(arr = []) {
  arr = arr.map(Number);
  let concreteByDays = [];

  let isWallCompleted = false;
  while (!isWallCompleted) {
    isWallCompleted = true;
    let crews = 0;

    for (let i = 0; i < arr.length; i++) {
      if (arr[i] < 30) {
        arr[i]++;
        isWallCompleted = false;
        crews++;
      }
    }

    if (crews > 0) {
      concreteByDays.push(crews * 195);
    }
  }

  console.log(concreteByDays.join(', '));
  console.log(`${concreteByDays.reduce((a, b) => a + b) * 1900} pesos`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([21, 25, 28]);