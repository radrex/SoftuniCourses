function solve(arr = []) {
  let key = +arr.shift();
  let result = '';

  for (let i = 0; i < arr.length; i++) {
    if (arr[i] === 'end') {
      break;
    }

    let decoded = '';
    for (let symbol of arr[i]) {
      decoded += String.fromCharCode(symbol.charCodeAt(0) - key)
    }

    let matches = decoded.matchAll(/@(?<name>[A-Za-z]+)[^@!:>-]*!(?<type>[GN])!/);
    for (let match of matches) {
      if (match.groups['type'] === 'G') {
        result += match.groups['name'] + '\n'
      }
    }
  }

  console.log(result.trimEnd());
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['3', 'CNdwhamigyenumje$J$', 'CEreelh-nmguuejnW$J$', 'CVwdq&gnmjkvng$Q$', 'end']);
solve(['3', "N}eideidmk$'(mnyenmCNlpamnin$J$", 'ddddkkkkmvkvmCFrqqru-nvevek$J$nmgievngeppqmkkkmnolmnnCEhq/vkievk$Q$', 'yyegiivoguCYdohqwlqh/kguimhk$J$', 'end']);
