function solve(text = []) {
  text = text[0].split('|');

  let letters = '';
  let lettersMatch = text[0].matchAll(/([#$%*&])(?<capLetters>[A-Z]+)(\1)/);
  for (let match of lettersMatch) {
    letters = match.groups['capLetters'];
  }

  for (let i = 0; i < letters.length; i++) {
    let asciiPattern = new RegExp(letters[i].charCodeAt(0) + ':(?<length>[0-9][0-9])');
    let asciiMatches = text[1].matchAll(asciiPattern);

    for (let asciiMatch of asciiMatches) {
      let length = +asciiMatch.groups['length'];
      let wordPattern = '(?<=\\s|^)' + letters[i] + '[^\\s]{' + length + '}(?=\\s|$)';
      wordPattern = new RegExp(wordPattern, 'gm');

      let wordMatch = text[2].match(wordPattern);
      console.log(wordMatch[0]);
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['sdsGGasAOTPWEEEdas$AOTP$|a65:1.2s65:03d79:01ds84:02! -80:07++ABs90:1.1|adsaArmyd Gara So La Arm Armyw21 Argo O daOfa Or Ti Sar saTheww The Parahaos']);
solve(['Urgent"Message.TO$#POAML#|readData79:05:79:0!2reme80:03--23:11{79:05}tak{65:11ar}!77:!23--)77:05ACCSS76:05ad|Remedy Por Ostream :Istream Post sOffices Office Of Ankh-Morpork MR.LIPWIG Mister Lipwig']);
