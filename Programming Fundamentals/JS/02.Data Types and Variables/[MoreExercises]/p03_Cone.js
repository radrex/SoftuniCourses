function solve(radius, height) {
  let volume = ((((1 / 3) * Math.PI) * (Math.pow(radius, 2))) * height).toFixed(4);
  let area = (Math.PI * radius * (radius + Math.sqrt(Math.pow(radius, 2) + Math.pow(height, 2)))).toFixed(4);

  console.log(`volume = ${volume}`);
  console.log(`area = ${area}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(3, 5);
solve(3.3, 7.8);
