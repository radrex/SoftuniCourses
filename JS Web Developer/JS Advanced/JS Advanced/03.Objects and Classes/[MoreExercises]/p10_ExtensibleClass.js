(function solve() {
  let id = 0;
  class Extensible {
    constructor() {
      this.id++;
    }

    extend(template) {
      for (let prop in template) {
        typeof template[prop] == 'function' ? Extensible.prototype[prop] = template[prop] : this[prop] = template[prop];
      }
    }
    
  }
  return Extensible;
})()

// Don't copy the code below in judge, you won't get any points, just the code above
let obj1 = new Extensible();
let obj2 = new Extensible();
let obj3 = new Extensible();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);