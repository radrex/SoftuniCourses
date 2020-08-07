function solve(phones = []) {
  phones = phones.join('').match(/\+359(-| )2\1\d{3}\1\d{4}\b/g);
  console.log(phones.join(', '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(["+359 2 222 2222,359-2-222-2222, +359/2/222/2222, +359-2 222 2222 +359 2-222-2222, +359-2-222-222, +359-2-222-22222 +359-2-222-2222"]);
