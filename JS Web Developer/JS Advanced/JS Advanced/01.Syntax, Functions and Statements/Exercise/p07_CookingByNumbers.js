function solve(arr) {
  let num = +arr.shift();

  let operations = {
    chop: num => num / 2,
    dice: num => Math.sqrt(num),
    spice: num => ++num,
    bake: num => num *= 3,
    fillet: num => +(num *= 0.8).toFixed(1)
  }

  for (let i = 0; i < arr.length; i++) {
    num = operations[arr[i]](num);
    console.log(num);
  }
}

solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);

/*
    let operations = {
      chop: function chop(num) { return num / 2; },
      dice: function dice(num) { return Math.sqrt(num); },
      spice: function spice(num) { return num++ },
      bake: function bake(num) { return num *= 3; },
      fillet: function filler(num) { return num *= 0.8; }
    }
*/
/*
    let operations = {
      chop: (num) => { return num / 2; },
      dice: (num) => { return Math.sqrt(num); },
      spice: (num) => { return ++num },
      bake: (num) => { return num *= 3; },
      fillet: (num) => { return +(num *= 0.8).toFixed(1); }
}
*/

//-------------- With params --------------
/*
    function solve(...params) {
      let num = +params.shift();

      let operations = {
        chop: (num) => num / 2,
        dice: (num) => Math.sqrt(num),
        spice: (num) => ++num,
        bake: (num) => num *= 3,
        fillet: (num) => +(num *= 0.8).toFixed(1)
      }

      for (let i = 0; i < params.length; i++) {
        num = operations[params[i]](num);
        console.log(num);
      }
    }

    solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
    solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
*/