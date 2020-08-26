function solve(arr) {
  let x1 = arr[0];
  let y1 = arr[1];

  let x2 = arr[2];
  let y2 = arr[3];

  if (Number.isInteger(getDistance(x1, y1, 0, 0))) {
    console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
  } else {
    console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
  }

  if (Number.isInteger(getDistance(x2, y2, 0, 0))) {
    console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
  } else {
    console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
  }

  if (Number.isInteger(getDistance(x1, y1, x2, y2))) {
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
  } else {
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
  }

  function getDistance(x1, y1, x2, y2) {
    let distX = x1 - x2;
    let distY = y1 - y2;
    return Math.sqrt(distX ** 2 + distY ** 2);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve([3, 0, 0, 4]);
solve([2, 1, 1, 1]);
