function solve(dates = []) {
  dates = dates.join('').matchAll(/\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b/g);

  for (let date of dates) {
    let day = date.groups['day'];
    let month = date.groups['month'];
    let year = date.groups['year'];
    console.log(`Day: ${day}, Month: ${month}, Year: ${year}`);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(["13/Jul/1928, 10-Nov-1934, , 01/Jan-1951,f 25.Dec.1937 23/09/1973, 1/Feb/2016"]);
