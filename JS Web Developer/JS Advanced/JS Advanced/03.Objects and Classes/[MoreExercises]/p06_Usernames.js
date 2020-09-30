function solve(input = []) {
  return [...new Set(input)].sort((a, b) => a.length - b.length || a.localeCompare(b)).join('\n');
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Ashton',
                   'Kutcher',
                   'Ariel',
                   'Lilly',
                   'Keyden',
                   'Aizen',
                   'Billy',
                   'Braston']));

console.log(solve(['Denise',
                   'Ignatius',
                   'Iris',
                   'Isacc',
                   'Indie',
                   'Dean',
                   'Donatello',
                   'Enfuego',
                   'Benjamin',
                   'Biser',
                   'Bounty',
                   'Renard',
                   'Rot']));