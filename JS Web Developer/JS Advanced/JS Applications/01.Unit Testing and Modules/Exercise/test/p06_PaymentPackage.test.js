const assert = require('chai').assert;
const PaymentPackage = require('../p06_PaymentPackage.js').PaymentPackage;

// Copy only the code below in judge to get points ---- 90/100
describe('Payment Package', () => {
  let package;
  beforeEach(() => package = new PaymentPackage('HR Services', 1500));

  let invalidNames = ['', 1, undefined, NaN, 2.2, Symbol(), new Date(), {}, []];
  let invalidValues = [-1, 'str', {}, [], Symbol(), undefined];
  //---------------------------------------------------------------------------------------------
  describe('Constructor', () => {
    it('Constructor should instantiate an object with the given arguments', () => {
      assert.instanceOf(package, PaymentPackage); // instantiate with arguments

      let expected = new PaymentPackage('HR Services', 1500);
      assert.deepEqual(package, expected);
    });

    it('"name" setter should throw error when trying to initialize with invalid value', () => {
      invalidNames.forEach(x => assert.throws(() => package = new PaymentPackage(x, 1)));
    });

    it('"value" setter should throw error when trying to initialize with invalid value', () => {
      //NaN -> not passing
      //Infinity -> not passing
      invalidValues.forEach(x => assert.throws(() => package = new PaymentPackage('HR', x)));
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('Public Setters', () => {
    it('"name" setter should throw error when trying to set invalid value', () => {
      invalidNames.forEach(x => assert.throws(() => package.name = x));
    });

    it('"value" setter should throw error when trying to set invalid value', () => {
      //NaN -> not passing
      //Infinity -> not passing
      invalidValues.forEach(x => assert.throws(() => package.value = x));
    });

    it('"VAT" setter should throw error when trying to set invalid value', () => {
      //NaN -> not passing
      //Infinity -> not passing
      invalidValues.forEach(x => assert.throws(() => package.VAT = x));
    });

    it('"active" setter should throw error when trying to set invalid value', () => {
      //NaN -> not passing
      //Infinity -> not passing
      invalidValues.forEach(x => assert.throws(() => package.active = x));
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('Public Getters', () => {
    it('"name" getter should return correct value', () => {
      assert.strictEqual(package.name, 'HR Services');
      package.name = 'Chips';
      assert.strictEqual(package.name, 'Chips');
    });

    it('"value" getter should return correct value', () => {
      assert.strictEqual(package.value, 1500);
      package.value = 2000;
      assert.strictEqual(package.value, 2000);
    });

    it('"VAT" setter should throw error when trying to set invalid value', () => {
      assert.strictEqual(package.VAT, 20);
      package.VAT = 10;
      assert.strictEqual(package.VAT, 10);
    });

    it('"active" setter should throw error when trying to set invalid value', () => {
      assert.strictEqual(package.active, true);
      package.active = false;
      assert.strictEqual(package.active, false);
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('Methods', () => {
    it('toString() method should return correct output message', () => {
      let expectedMsg = 'Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800';
      assert.strictEqual(package.toString(), expectedMsg);

      //---------------- TEST 2 ----------------
      expectedMsg = 'Package: Consultation\n- Value (excl. VAT): 800\n- Value (VAT 20%): 960';
      package.name = 'Consultation';
      package.value = 800;
      assert.strictEqual(package.toString(), expectedMsg);
      
      //---------------- TEST 3 ----------------
      expectedMsg = 'Package: Chips (inactive)\n- Value (excl. VAT): 2000\n- Value (VAT 10%): 2200';
      package.name = 'Chips';
      package.value = 2000;
      package.VAT = 10;
      package.active = false;
      assert.strictEqual(package.toString(), expectedMsg);
    });
  });
});