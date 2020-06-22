function solve(name, lastName, hairColor) {
  let person = { 
    name, 
    lastName, 
    hairColor,
  };

  console.log(JSON.stringify(person));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('George', 'Jones', 'Brown');
