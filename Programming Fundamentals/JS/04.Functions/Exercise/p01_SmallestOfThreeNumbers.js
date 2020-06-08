function smallestNumber(a, b, c) {
  let smallestNumber = 0;

  if (a <= b && a <= c) {
    smallestNumber = a;
  } else if (b <= a && b <= c) {
    smallestNumber = b;
  } else {
    smallestNumber = c;
  }

  return smallestNumber;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(smallestNumber(2, 5, 3));
console.log(smallestNumber(600, 342, 123));
console.log(smallestNumber(25, 21, 4));
