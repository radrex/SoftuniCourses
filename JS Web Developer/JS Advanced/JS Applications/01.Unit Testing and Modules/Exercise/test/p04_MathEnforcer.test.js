const assert = require('chai').assert;
const mathEnforcer = require('../p04_MathEnforcer.js').mathEnforcer;

// Copy only the code below in judge to get points ---- 100/100
describe('Math Enforcer', function() {
  describe('Add Five', function() {
    it('Function should return undefined when passed parameter differs number', () => {
      let invalidArgs = ['str', Symbol(), {}, function(){}, new Date()];
      invalidArgs.forEach(x => assert.isUndefined(mathEnforcer.addFive(x)));
    });

    it('Function should return correct result type', () => {
      //2n -> undefined (will not be valid with IsNumber, because (2n + 5) -> 5 lacks 'n' literal -> (BigInt + number))
      //NaN -> NaN (will be valid with IsNumber, because NaN is a number)
      //Infinity -> Infinity (will be valid with IsNumber, because Infinity is a number)
      let validArgs = [2, 2.5, 0xFF, 123e-5, 7.3e9, 0b11111111, 0o377, NaN, Infinity];
      validArgs.forEach(x => assert.isNumber(mathEnforcer.addFive(x)));
    });

    it('Function should return correct result', () => {
      assert.strictEqual(mathEnforcer.addFive(2), 7);
      assert.strictEqual(mathEnforcer.addFive(-2), 3);
      assert.closeTo(mathEnforcer.addFive(0.5), 5.5, 0.01);
    });
  });
  //---------------------------------------------------------------------------------------
  describe('Subtract Ten', function() {
    it('Function should return undefined when passed parameter differs number', () => {
      let invalidArgs = ['str', Symbol(), {}, function(){}, new Date()];
      invalidArgs.forEach(x => assert.isUndefined(mathEnforcer.subtractTen(x)));
    });

    it('Function should return correct result', () => {
      assert.strictEqual(mathEnforcer.subtractTen(-10), -20);
      assert.strictEqual(mathEnforcer.subtractTen(20), 10);
      assert.closeTo(mathEnforcer.subtractTen(10.5), 0.5, 0.01);
    });
  });
  //---------------------------------------------------------------------------------------
  describe('Sum', function() {
    it('Function should return undefined when one or both passed parameters differs number', () => {
      let invalidArgs = [['str', 2], [2, 'str'], [Symbol(), 1], [function(){}, 1], [new Date(), 1]];
      invalidArgs.forEach(([x, y]) => assert.isUndefined(mathEnforcer.sum(x, y)));
    });

    it('Function should sum correctly', () => {
      assert.strictEqual(mathEnforcer.sum(1, 1), 2);
      assert.strictEqual(mathEnforcer.sum(-1, 1), 0);
      assert.closeTo(mathEnforcer.sum(1.5, 1.2), 2.7, 0.01);
    });
  });
});