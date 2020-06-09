function printDNA(length) {
  let sequence = 'ATCGTTAGGG'.split('');

  for (let i = 1; i <= length; i++) {
    let [a, b] = sequence.splice(0, 2);

    if (i === 1 || i % 4 === 1) {
      console.log(`**${a}${b}**`);
    } else if (i === 2 || i % 4 === 2) {
      console.log(`*${a}--${b}*`);
    } else if (i === 3 || i % 4 === 3) {
      console.log(`${a}----${b}`);
    } else if (i === 4 || i % 4 === 0) {
      console.log(`*${a}--${b}*`);
    }

    sequence.push(a)
    sequence.push(b)
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
printDNA(4);
printDNA(10);
