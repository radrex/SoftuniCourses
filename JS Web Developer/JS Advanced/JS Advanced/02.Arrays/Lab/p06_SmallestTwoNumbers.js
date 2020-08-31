//------------------ DECLARATIVE APPROACH ------------------
function solve(numbers = []) {
  return numbers.slice()
                .sort((a, b) => a - b)
                .slice(0, 2)
                .join(' ');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve([30, 15, 50, 5]));
console.log(solve([3, 0, 10, 4, 7, 3]));
