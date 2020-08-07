function solve(names = []) {
  names = names.join('').match(/\b[A-Z][a-z]+ [A-Z][a-z]+\b/g);
  console.log(names.join(' '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(["Ivan Ivanov, Ivan ivanov, ivan Ivanov, IVan Ivanov, Test Testov, Ivan	Ivanov"]);
