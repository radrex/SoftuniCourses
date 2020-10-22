function solve(input) {
  return JSON.parse(input).reduce((acc, value) => ({...acc, ...value}), {});
}

// Don't copy the code below in judge, you won't get any points, just the code above
console.log(solve(`[{"canMove": true},{"canMove":true, "doors": 4},{"capacity": 5}]`));
console.log(solve(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`));
