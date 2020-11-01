const assert = require('chai').assert;
const mod = require('../p02_PlayingCards.js');

// Copy only the code below in judge to get points
describe('Playing Cards', function() {
  it('Class should throw error during initialization', () => {
    assert.throws(() => new mod.Card('1', 'C'), Error);
  });

  it('Class function toString should return correct result', function() {
    assert.strictEqual(new mod.Card('A', 'S').toString(), 'A\u2660');
    assert.strictEqual(new mod.Card('10', 'H').toString(), '10\u2665');
  });
});
