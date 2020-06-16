function solve(tokens = []) {
  let inventory = tokens.shift().split(' ');

  while (tokens.length !== 0) {
    let command = tokens.shift().split(' ');

    switch (command.shift()) {
      case 'Buy':       buy(command[0]);        break;
      case 'Trash':     trash(command[0]);      break;
      case 'Repair':    repair(command[0]);     break;
      case 'Upgrade':   upgrade(command[0]);    break;
      default:                                  break;
    }
  }

  console.log(inventory.join(' '));

  function buy(equipment) {
    if (!inventory.includes(equipment)) {
      inventory.push(equipment);
    }
  }

  function trash(equipment) {
    if (inventory.includes(equipment)) {
      inventory = inventory.filter(x => x !== equipment);
    }
  }

  function repair(equipment) {
    if (inventory.includes(equipment)) {
      inventory = inventory.filter(x => x !== equipment);
      inventory.push(equipment);
    }
  }

  function upgrade(equipment) {
    let index = inventory.indexOf(equipment.split('-')[0]);

    if (index !== -1) {
      inventory.splice(index + 1, 0, equipment.replace('-', ':'));
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['SWORD Shield Spear',
       'Buy Bag',
       'Trash Shield',
       'Repair Spear',
       'Upgrade SWORD-Steel']);
       
solve(['SWORD Shield Spear',
       'Trash Bow',
       'Repair Shield',
       'Upgrade Helmet-V']);