function solve(arr = []) {
  let [letters, casing] = arr;
  let totalSum = 0;

  switch (casing) {
    case 'LOWERCASE':
      letters = letters.match(/[a-z]/g);
      break;
    case 'UPPERCASE':
      letters = letters.match(/[A-Z]/g);
      break;

    default:
      break;
  }

  letters.forEach(x => totalSum += x.charCodeAt(0));
  console.log(`The total sum is: ${totalSum}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['HelloFromMyAwesomePROGRAM', 'LOWERCASE']);
solve(['AC/DC', 'UPPERCASE']);
