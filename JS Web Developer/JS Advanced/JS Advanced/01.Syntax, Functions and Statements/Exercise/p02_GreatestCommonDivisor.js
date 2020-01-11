function solve(x, y) {
  while(y) {
    let temp = y;
    y = x % y;
    x = temp;
  }
  return x;
}

console.log(solve(15, 5));
console.log(solve(2154, 458));

//------------- RECURSIVE --------------
/*
    function gcd_rec(a, b) {
      if (b) {
          return gcd_rec(b, a % b);
      } else {
          return Math.abs(a);
      }
    }

    console.log(gcd_rec(15, 5));
    console.log(gcd_rec(2154, 458));
*/

//------------- ITERATIVE --------------
/*
    function gcd(a,b) {
      a = Math.abs(a);
      b = Math.abs(b);
      if (b > a) {
        let temp = a; 
        a = b; 
        b = temp;
      }

      while (true) {
          if (b == 0) {
            return a;
          } 
          a %= b;

          if (a == 0) { 
            return b 
          };
          b %= a;
      }
    }

    console.log(gcd(15, 5));
    console.log(gcd(2154, 458));
*/