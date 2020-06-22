function solve(tokens = []) {
  let cats = [];

  class Cat {
    constructor(name, age) {
      this.name = name;
      this.age = age;
    }

    meow() {
      return `${this.name}, age ${this.age} says Meow`;
    }
  }

  for (let i = 0; i < tokens.length; i++) {
    let catData = tokens[i].split(' ');
    let [name, age] = [catData[0], catData[1]];

    cats.push(new Cat(name, age));
  }

  for (let cat of cats) {
    console.log(cat.meow());
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Mellow 2', 'Tom 5']);
