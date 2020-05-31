function solve(base, increment) {
  let height = 0.0;
  let gold = 0;
  let stone = 0;
  let marble = 0;
  let lapisLazuli = 0;

  let steps = 0;
  while (base > 2) {
    steps++;
    height += increment;

    //----------- BLOCKS -----------
    let blocks = base * base;
    base -= 2;
    let stoneBlocks = base * base;
    blocks -= stoneBlocks;

    //----------- STONE, MARBLE, LAPIS LAZULI -----------
    stone += stoneBlocks * increment;
    if (steps % 5 === 0) {
      lapisLazuli += blocks * increment;
    } else {
      marble += blocks * increment;
    }
  }

  height += increment;

  //----------- GOLD -----------
  gold += ((base * base) * increment);

  console.log(`Stone required: ${Math.ceil(stone)}`);
  console.log(`Marble required: ${Math.ceil(marble)}`);
  console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuli)}`);
  console.log(`Gold required: ${Math.ceil(gold)}`);
  console.log(`Final pyramid height: ${Math.floor(height)}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(11, 1);
solve(11, 0.75);
solve(12, 1);
solve(23, 0.5);