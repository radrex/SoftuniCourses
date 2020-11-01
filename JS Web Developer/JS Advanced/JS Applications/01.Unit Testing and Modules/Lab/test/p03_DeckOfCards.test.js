const assert = require('chai').assert;
const mod = require('../p03_DeckOfCards.js');

// Copy only the code below in judge to get points
describe('Deck of Cards', function() {
  it('Function should print correctly', () => {
    let result = mod.printDeckOfCards(['AS', '10D', 'KH', '2C']);
    assert.strictEqual(result, 'A\u2660 10\u2666 K\u2665 2\u2663');
  });

  it('Function should return error message', () => {
    let result = mod.printDeckOfCards(['5S', '3D', 'QD', '1C']);
    assert.strictEqual(result, 'Invalid card: 1C');
  });
});
