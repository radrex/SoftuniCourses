const assert = require('chai').assert;
const StringBuilder = require('../p05_StringBuilder.js').StringBuilder;

// Copy only the code below in judge to get points ---- 70/100
describe('String Builder', function() {
  let sb;
  beforeEach(() => sb = new StringBuilder('SCV Ready!'));
  //---------------------------------------------------------------------------------------------
  describe('Constructor', () => {
    it('Constructor should instantiate an object with or without a given argument', () => {
      assert.instanceOf(sb, StringBuilder); // instantiate with argument
      assert.instanceOf(new StringBuilder(), StringBuilder);  // instantiate without argument
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('_vrfyParam', () => {
    it('Function should throw TypeError the passed argument is not a string', () => {
      //undefined -> not passing
      let args = [1, 1.1, NaN, Infinity, 0xFF, 123e-5, 7.3e9, 0b11111111, 0o377, 1n, {}, [], function(){}, Symbol(), new Date()];
      args.forEach(x => assert.throws(() => new StringBuilder(x), TypeError, 'Argument must be string'));
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('Append', () => {
    it('Function should append correctly', () => {
      sb.append(' Woo hoo! Overtime!');
      assert.strictEqual(sb.toString(), 'SCV Ready! Woo hoo! Overtime!');
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('Prepend', () => {
    it('Function should prepend correctly', () => {
      sb.prepend('Huh? ');
      assert.strictEqual(sb.toString(), 'Huh? SCV Ready!');
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('InsertAt', () => {
    it('Function should insert string starting from passed index', () => {
      sb.insertAt('Uh-huh... ', 4);
      assert.strictEqual(sb.toString(), 'SCV Uh-huh... Ready!');
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('Remove', () => {
    it('Function should remove N characters starting from passed index', () => {
      sb.remove(3, 7);
      assert.strictEqual(sb.toString(), 'SCV');
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('ToString', () => {
    it('Function should return joined array as string', () => {
      assert.strictEqual(sb.toString(), 'SCV Ready!');
    });
  });
});