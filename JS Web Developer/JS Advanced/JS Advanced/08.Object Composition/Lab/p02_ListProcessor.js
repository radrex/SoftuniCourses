function solve(input = []) {
  const listProcessorBuilder = function() {
    let collection = [];

    return {
      add: (item) => collection.push(item),
      remove: (item) => collection = collection.filter(x => x !== item),
      print: () => console.log(collection.join(',')),
    }
  }

  let listProcessor = listProcessorBuilder();
  input.map(x => x.split(' ')).forEach(([command, argument]) => listProcessor[command](argument));
}

// Don't copy the code below in judge, you won't get any points, just the code above
solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);
