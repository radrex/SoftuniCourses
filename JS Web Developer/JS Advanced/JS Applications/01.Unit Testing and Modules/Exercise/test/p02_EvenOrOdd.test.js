const assert = require('chai').assert;
const isOddOrEven = require('../p02_EvenOrOdd.js').isOddOrEven;

// Copy only the code below in judge to get points ---- 100/100
describe('Even or Odd', function() {
  it('Function should return undefined when passed parameter differs string', () => {
    let params = [1, 1.1, NaN, Infinity, 0xFF, 123e-5, 7.3e9, 0b11111111, 0o377, 1n, undefined, {}, [], function(){}, Symbol(), new Date()];
    params.forEach(x => assert.isUndefined(isOddOrEven(x), `Type ${typeof x} didn't return undefined`));
  });

  it('Function should return "even" when passed string has even length', () => {
    assert.strictEqual(isOddOrEven('test'), 'even', 'String length is not an even number');
  });

  it('Function should return "odd" when passed string has odd length', () => {
    assert.strictEqual(isOddOrEven('xyz'), 'odd', 'String length is not an odd number');
  });
});