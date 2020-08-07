function solve(arr = []) {
  let text = [...arr[0]];
  let pattern = [...arr[1]];

  while (true) {
    let firstIndex = text.join('').indexOf(pattern.join(''));
    let lastIndex = text.join('').lastIndexOf(pattern.join(''));
  
    if (firstIndex !== -1 && lastIndex !== -1 && firstIndex !== lastIndex && pattern.length > 0) {
      text.splice(firstIndex, pattern.length);
      text.splice(lastIndex - pattern.length, pattern.length);
      pattern.splice(pattern.length / 2, 1);

      console.log(`Shaked it.`);
    } else {
      console.log(`No shake.`);
      break;
    }
  }

  console.log(text.join(''));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['astalavista baby', 'sta']);
solve(['##mtm!!mm.mm*mtm.#', 'mtm']);
