const assert = require('chai').assert;
const Console = require('../p08_CSharpConsole.js').Console;

// Copy only the code below in judge to get points ---- 100/100
describe('C# Console', () => {
  let console;
  beforeEach(() => console = new Console());

  //---------------------------------------------------------------------------------------------
  describe('Constructor', () => {
    it('Constructor should instantiate an object without arguments', () => {
      assert.instanceOf(console, Console);
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('Methods', () => {
    describe('writeLine()', () => {
      it('Function should return stringified message', () => {
        let msg = Console.writeLine({ Marauder: 'KABOOM Baby'});
        let expected = JSON.stringify({ Marauder: 'KABOOM Baby'});
        assert.strictEqual(msg, expected);
      });

      it('Function should return string message', () => {
        let msg = Console.writeLine('KABOOM Baby');
        assert.strictEqual(msg, 'KABOOM Baby');
      });

      it("Function should throw TypeError when passed arguments are more than one and the first one's type differs string", () => {
        assert.throws(() => Console.writeLine([], 'Say the word, baby...', ['zerg array']), TypeError,'No string format given!');
      });

      it('Function should throw RangeError when parameters count is larger than placeholders count', () => {
        assert.throws(() => Console.writeLine('{0} {1} ot Testovo Pole','Test','Testov','RageQuit'), RangeError,'Incorrect amount of parameters given!');
        assert.throws(() => Console.writeLine('{0} {1} ot Testovo Pole','Test'), RangeError,'Incorrect amount of parameters given!');
      });
      
      it('Function should throw RangeError if placeholder indexes exceed parameters count', () => {
        assert.throws(() => Console.writeLine('{0} {666} ot Testovo Pole','Test','Testov'),RangeError,'Incorrect placeholders given!');
      });

      it("Function should replace placeholders correctly", () => {
        assert.strictEqual(Console.writeLine('{0} {1} ot Testovo Pole','Test','Testov'),'Test Testov ot Testovo Pole');
      });
    });
  });
});