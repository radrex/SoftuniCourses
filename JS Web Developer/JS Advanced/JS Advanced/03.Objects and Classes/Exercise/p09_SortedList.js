class SortedList {
  constructor() {
    this.list = [];
    this.size = this.list.length;
  }

  add(element) {
    this.list.push(element);
    this.size++;
    this.list.sort((a, b) => a - b);
  }

  remove(index) {
    if (index < 0 || index >= this.list.length) {
      throw new Error('Index out of bound');
    }
    this.list.splice(index, 1);
    this.size--;
  }

  get(index) {
    if (index < 0 || index >= this.list.length) {
      throw new Error('Index out of bound');
    }
    return this.list[index];
  }
}

// Don't copy the code below in judge, you won't get any points, just the code above
let list = new SortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
