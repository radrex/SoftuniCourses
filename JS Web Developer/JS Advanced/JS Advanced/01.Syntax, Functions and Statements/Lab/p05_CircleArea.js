function solve(x) {
  let type = typeof(x);
  
  if (type === "number") {
    let circleArea = Math.pow(x, 2) * Math.PI;
    console.log(circleArea.toFixed(2));
  }
  else {
    console.log(`We can not calculate the circle area, because we receive a ${type}.`)
  }
}

solve(5);
solve("name");