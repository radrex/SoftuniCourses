const assert = require('chai').assert;
const mod = require('../p01_SubSum.js');

// Copy only the code below in judge to get points
describe('Sub Sum', function() {
  it('Function should return NaN', () => {
    assert.isNaN(mod.subSum('text', 0, 2), NaN);
    assert.isNaN(mod.subSum([10, 'twenty', 30, 40], 0, 2), NaN);
  });

  it('Function should return correct result', () => {
    assert.strictEqual(mod.subSum([], 1, 2), 0);
    assert.strictEqual(mod.subSum([10, 20, 30, 40, 50, 60], 3, 300), 150);
  });
});
