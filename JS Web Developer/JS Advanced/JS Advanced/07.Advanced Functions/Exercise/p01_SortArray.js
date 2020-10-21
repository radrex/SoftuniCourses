function solve(numbers = [], sortType) {
  const actions = {
    'asc': () => numbers.slice().sort((a, b) => a - b),
    'desc': () => numbers.slice().sort((a, b) => b - a),
  };

  return actions[sortType]();
}

// Don't copy the code below in judge, you won't get any points, just the code above
console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));