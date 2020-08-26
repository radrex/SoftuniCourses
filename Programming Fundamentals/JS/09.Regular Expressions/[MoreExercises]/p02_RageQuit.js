function solve(text = []) {
  let series = text[0].split(/[0-9]+/).filter((x) => x != '');
  let repeaters = text[0].split(/[^0-9]+/).filter((x) => x != '');
  let result = '';
  for (let i = 0; i < series.length; i++) {
    result += series[i].toUpperCase().repeat(repeaters[i]);
  }

  console.log(`Unique symbols used: ${[...new Set(result)].length}`);
  console.log(result);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['a3']);
solve(['aSd2&5s@1']);
