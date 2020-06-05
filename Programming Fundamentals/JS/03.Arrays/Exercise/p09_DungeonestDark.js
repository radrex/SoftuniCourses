function solve(tokens) {
  let health = 100;
  let coins = 0;

  let dungeonRooms = tokens[0].split('|');

  for (let i = 0; i < dungeonRooms.length; i++) {
    let room = dungeonRooms[i].split(' ');
    switch (room[0]) {
      case 'potion':
        let potionHP = +room[1];

        if (health + potionHP <= 100) {
          health += potionHP;
          console.log(`You healed for ${potionHP} hp.`);
        } else {
          let heal = 100 - health;
          health += heal;
          console.log(`You healed for ${heal} hp.`);
        }

        console.log(`Current health: ${health} hp.`);
        break;

      case 'chest':
        let foundCoins = +room[1];
        coins += foundCoins;
        console.log(`You found ${foundCoins} coins.`);
        break;

      default:
        let monsterAttack = +room[1];
        health -= monsterAttack;

        if (health > 0) {
          console.log(`You slayed ${room[0]}.`);
        } else {
          console.log(`You died! Killed by ${room[0]}.`);
          console.log(`Best room: ${i+1}`);
          return;
        }
        break;
    }
  }

  console.log("You've made it!");
  console.log(`Coins: ${coins}`);
  console.log(`Health: ${health}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['rat 10|bat 20|potion 10|rat 10|chest 100|boss 70|chest 1000']);
solve(['cat 10|potion 30|orc 10|chest 10|snake 25|chest 110']);
