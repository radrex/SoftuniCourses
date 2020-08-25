function solve(input = []) {
  let matches = input[0].match(/(?<=\s)[A-Za-z0-9]+[_.-]*[A-Za-z0-9]+@[A-Za-z]+-*[A-Za-z]+(?:\.[A-Za-z]+-*[A-Za-z])+/g);
  if (matches !== null) {
    matches.forEach(x => console.log(x));
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Please contact us at: support@github.com.']);
solve(['Just send email to s.miller@mit.edu and j.hopking@york.ac.uk for more information.']);
solve(['Many users @ SoftUni confuse email addresses. We @ Softuni.BG provide high-quality training @ home or @ class. –- steve.parker@softuni.de.']);
