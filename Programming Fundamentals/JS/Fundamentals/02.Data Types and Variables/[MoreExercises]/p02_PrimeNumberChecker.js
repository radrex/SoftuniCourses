function isPrime(n) {
  let isPrime = true;

  for (let i = 2; i < Math.ceil(Math.sqrt(n)); i++)
  {
    if (n % i === 0) {
      isPrime = false;
      return isPrime;
    }
  }
  return isPrime;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(isPrime(7));
console.log(isPrime(8));
console.log(isPrime(81));
