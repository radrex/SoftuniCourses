let expect = require('chai').expect;
let createCalculator = require("../p07_AddSubtract.js").createCalculator;

// Copy only the code below in judge to get points
describe("Add/Subtract", function () {
  let calc;

  beforeEach(function () {
    calc = createCalculator();
  });

  it("Should return 0 for get;", function () {
    let value = calc.get();
    expect(value).to.be.equal(0);
  });

  it("Should return 5 after add(2); add(3);", function () {
    calc.add(2);
    calc.add(3);
    let value = calc.get();
    expect(value).to.be.equal(5);
  });

  it("shoul return -5 after subtract(3); subtract(2)", function () {
    calc.subtract(3);
    calc.subtract(2);
    let value = calc.get();
    expect(value).to.be.equal(-5);
  });

  it("Should return 4.2 after add(5.3); subtract(1.1);", function () {
    calc.add(5.3);
    calc.subtract(1.1);
    let value = calc.get();
    expect(value).to.be.equal(5.3 - 1.1);
  });

  it("Should return 2 after add(10); subtract('7'); add('-2'); subtract(-1)", function () {
    calc.add(10);
    calc.subtract('7');
    calc.add('-2');
    calc.subtract(-1);
    let value = calc.get();
    expect(value).to.be.equal(2);
  });

  it("Should return NaN for add(string)", function () {
    calc.add('hello');
    let value = calc.get();
    expect(value).to.be.NaN;
  });

  it("Should return NanN for subtarct(string)", function () {
    calc.subtract('hello');
    let value = calc.get();
    expect(value).to.be.NaN;
  });
});