function solve(input) {
  let cars = [];

  const dataProcessor = function() {
    return {
      create: (name) => cars.push({[name]: {}}),
      createInherit: function(name1, name2) {
        let car1 = {[name1]: {}};
        let car2 = cars.find(x => x.hasOwnProperty(name2));

        if (car2 != undefined) {
          // car1 = {...car1[name1], ...car2[name2]}; // prototypes and inheritance ?
        }
        cars.push(car1);
      },
      set: function(name, prop, propValue) {
        let car = cars.find(x => x.hasOwnProperty(name));
        if (car != undefined) {
          car[name][prop] = propValue;
        }
      },
      print: function(name) {
        let car = cars.find(x => x.hasOwnProperty(name));
        if (car != undefined) {
          let message = [];
          Object.entries(car[name]).forEach(([key, value]) => message.push(`${key}:${value}`));
          console.log(message.join(', '));
        }
      }
    }
  };

  let processor = dataProcessor();

  for (let arr of input) {
    let args = arr.split(' ');
    switch (args[0]) {
      case 'create':
        if (args.includes('inherit')) {
          processor.createInherit(args[1], args[3]);
        } else {
          processor.create(args[1]);
        }
        break;
  
      case 'set':
        processor.set(args[1], args[2], args[3]);
        break;
  
      case 'print':
        processor.print(args[1]);
        break;
    
      default:
        break;
    }
  }
}

solve(['create c1',
       'create c2 inherit c1',
       'set c1 color red',
       'set c2 model new',
       'print c1',
       'print c2']);