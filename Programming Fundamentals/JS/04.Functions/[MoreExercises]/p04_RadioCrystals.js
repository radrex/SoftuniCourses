function refineCrystal(tokens = []) {
  let thicknessTarget = tokens.shift();

  while (tokens.length !== 0) {
    let crystalOre = tokens.shift();
    console.log(`Processing chunk ${crystalOre} microns`);

    crystalOre = cut(crystalOre, thicknessTarget);
    crystalOre = lap(crystalOre, thicknessTarget);
    crystalOre = grind(crystalOre, thicknessTarget);
    crystalOre = etch(crystalOre, thicknessTarget);
    crystalOre = xray(crystalOre, thicknessTarget);
  }

  function transportAndWash (crystalOre) {
    console.log(`Transporting and washing`);
    return Math.floor(crystalOre);
  }

  function cut(crystalOre, thicknessTarget) {
    let counter = 0;
    while (crystalOre / 4 >= thicknessTarget - 1) {
      crystalOre /= 4;
      counter++;
    }

    if (counter !== 0) {
      console.log(`Cut x${counter}`);
      crystalOre = transportAndWash(crystalOre);
    }
    return crystalOre;
  }

  function lap(crystalOre, thicknessTarget) {
    let counter = 0;
    while (crystalOre * 0.80 >= thicknessTarget - 1) {
      crystalOre *= 0.80;
      counter++;
    }

    if (counter !== 0) {
      console.log(`Lap x${counter}`);
      crystalOre = transportAndWash(crystalOre);
    }
    return crystalOre;
  }

  function grind(crystalOre, thicknessTarget) {
    let counter = 0;
    while (crystalOre - 20 >= thicknessTarget - 1) {
      crystalOre -= 20;
      counter++;
    }

    if (counter !== 0) {
      console.log(`Grind x${counter}`);
      crystalOre = transportAndWash(crystalOre);
    }
    return crystalOre;
  }

  function etch(crystalOre, thicknessTarget) {
    let counter = 0;
    while (crystalOre - 2 >= thicknessTarget - 1) {
      crystalOre -= 2;
      counter++;
    }

    if (counter !== 0) {
      console.log(`Etch x${counter}`);
      crystalOre = transportAndWash(crystalOre);
    }
    return crystalOre;
  }

  function xray(crystalOre, thicknessTarget) {
    if (crystalOre === thicknessTarget - 1) {
      crystalOre += 1;
      console.log(`X-ray x1`);
      console.log(`Finished crystal ${crystalOre} microns`);
    } else {
      console.log(`Finished crystal ${crystalOre} microns`);
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
refineCrystal([1375, 50000]);
refineCrystal([1000, 4000, 8100]);