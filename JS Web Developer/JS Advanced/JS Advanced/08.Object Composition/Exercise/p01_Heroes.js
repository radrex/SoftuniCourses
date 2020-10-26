function solve() {
  const actions = (state) => ({
    cast: (spell) => {
      console.log(`${state.name} cast ${spell}`);
      state.mana--;
    },
    fight: () => {
      console.log(`${state.name} slashes at the foe!`);
      state.stamina--;
    }
  });

  return {
    mage: (name) => {
      let state = {
        name,
        health: 100,
        mana: 100,
      };
      return Object.assign(state, actions(state));
    },
    fighter: (name) => {
      let state = {
        name,
        health: 100,
        stamina: 100,
      };
      return Object.assign(state, actions(state));
    },
  }
}

// Don't copy the code below in judge, you won't get any points, just the code above
let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);