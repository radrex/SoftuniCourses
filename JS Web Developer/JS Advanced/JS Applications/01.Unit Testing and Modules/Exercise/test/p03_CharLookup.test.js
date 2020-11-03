const assert = require('chai').assert;
const lookupChar = require('../p03_CharLookup.js').lookupChar;

// Copy only the code below in judge to get points ---- 100/100
describe('Char Lookup', function() {
  it('Function should return undefined when passed parameter differs string', () => {
    let args = [[{}, 1],
                ['string', {}],
                [1, 1],
                [function(){}, 2],
                ['validString', 2.2],
                ['anotherValidString', Symbol()]];
  
    args.map(([key, value]) => assert.isUndefined(lookupChar(key, value), 'Invalid argument type passed'));
  });

  it('Function should return "Incorrect index" when passing invalid index', () => {
    assert.strictEqual(lookupChar('text', -1), 'Incorrect index', 'Index out of bounds');
    assert.strictEqual(lookupChar('text', 4), 'Incorrect index', 'Index out of bounds');
  });

  it('Function should correct character', () => {
    assert.strictEqual(lookupChar('xyz', 2), 'z');
    assert.strictEqual(lookupChar('xyz', 0), 'x');
  });
});