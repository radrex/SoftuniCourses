class Hex {
  constructor(value) {
    this.value = +value;
  }

  valueOf() { return this.value; }
  toString() { return `0x${this.value.toString(16).toUpperCase()}`; }

  plus(number) {
    let result = (this.value + Number(number.valueOf()));
    return new Hex(result);
  }

  minus(number) {
    let result = (this.value - Number(number.valueOf()));
    return new Hex(result);
  }

  parse(hexString) {
    return parseInt(hexString, 16);
  }
}

// Don't copy the code below in judge, you won't get any points, just the code above
let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === '0xF');
