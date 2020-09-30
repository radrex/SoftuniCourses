class Rectangle {
  constructor(width, height, color) {
    this.width = +width;
    this.height = +height;
    this.color = color;
  }

  calcArea() { return this.width * this.height; }
}

// Don't copy the code below in judge, you won't get any points, just the code above
let rect = new Rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
