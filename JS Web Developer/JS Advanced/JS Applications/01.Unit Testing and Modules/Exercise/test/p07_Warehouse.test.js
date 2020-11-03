const assert = require('chai').assert;
const Warehouse = require('../p07_Warehouse.js').Warehouse;

// Copy only the code below in judge to get points ---- 100/100
describe('Warehouse', () => {
  let warehouse;
  beforeEach(() => warehouse = new Warehouse(1500));

  let invalidArgs = [-1, 0, 'str', [], {}, Symbol(), undefined, new Date()];
  //---------------------------------------------------------------------------------------------
  describe('Constructor', () => {
    it('Constructor should instantiate an object with the given argument', () => {
      assert.instanceOf(warehouse, Warehouse); // instantiate with arguments

      let expected = new Warehouse(1500);
      assert.deepEqual(warehouse, expected);
    });

    it('"capacity" setter should throw error when trying to initialize with invalid value', () => {
      invalidArgs.forEach(x => assert.throws(() => warehouse = new Warehouse(x)));
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('Public Setters', () => {
    it('"capacity" setter should throw error when trying to set invalid value', () => {
      invalidArgs.forEach(x => assert.throws(() => warehouse.capacity = x));
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('Public Getters', () => {
    it('"capacity" getter should return correct value', () => {
      assert.strictEqual(warehouse.capacity, 1500);
      warehouse.capacity = 2000;
      assert.strictEqual(warehouse.capacity, 2000);
    });
  });
  //---------------------------------------------------------------------------------------------
  describe('Methods', () => {
    describe('addProduct()', () => {
      it('Function should add product to warehouse', () => {
        let output = warehouse.addProduct('Food', 'Laina', 1500);
        let expected = {Laina:1500};

        assert.strictEqual(JSON.stringify(output), JSON.stringify(expected));
      });

      it('Function should add quantity to already existing products if there is space', () => {
        warehouse.addProduct('Food', 'Chips', 1000);
        let output = warehouse.addProduct('Food', 'Chips', 500);
        let expected = {Chips:1500};

        assert.strictEqual(JSON.stringify(output), JSON.stringify(expected));
      });

      it('Function should throw error when trying to add a product to a full warehouse', () => {
        warehouse.addProduct('Food', 'Laina', 1500);
        assert.throws(() => warehouse.addProduct('Food', 'Sushi', 10), 'There is not enough space or the warehouse is already full');
      });
    });
    //---------------------------------------------------------------------------------------------
    describe('orderProducts()', () => {
      it('Function should sort products of passed type in descending order by quantity', () => {
        warehouse.addProduct('Food', 'Cyanid', 200);
        warehouse.addProduct('Food', 'Chips', 500);

        let foods = warehouse.orderProducts('Food');
        let expected = {Chips:500, Cyanid:200};
        assert.strictEqual(JSON.stringify(foods), JSON.stringify(expected));

        //-------------------------------------------------------------------
        warehouse.addProduct('Drink', 'Cola', 200);
        warehouse.addProduct('Drink', 'CorosiveAcid', 150);
        warehouse.addProduct('Drink', 'Mercury', 50);
        warehouse.addProduct('Drink', 'LiquidNitrogen', 50);

        let drinks = warehouse.orderProducts('Drink');
        expected = {Cola:200, CorosiveAcid:150, Mercury:50, LiquidNitrogen:50};
        assert.strictEqual(JSON.stringify(drinks), JSON.stringify(expected));
      });
    });
    //---------------------------------------------------------------------------------------------
    describe('occupiedCapacity()', () => {
      it('Function should return the occupied capacity in the warehouse', () => {
        warehouse.addProduct('Food', 'Cyanid', 200);
        warehouse.addProduct('Food', 'Chips', 500);
        assert.strictEqual(warehouse.occupiedCapacity(), 700);

        warehouse.addProduct('Food', 'Chips', -500);
        assert.strictEqual(warehouse.occupiedCapacity(), 200);
      });
    });
    //---------------------------------------------------------------------------------------------
    describe('revision()', () => {
      it('Function should return all warehouse products', () => {
        warehouse.addProduct('Food', 'Cyanid', 200);
        warehouse.addProduct('Food', 'Chips', 500);
        warehouse.addProduct('Drink', 'Cola', 200);

        let output = warehouse.revision();
        let expected = 'Product type - [Food]\n- Cyanid 200\n- Chips 500\nProduct type - [Drink]\n- Cola 200';
        assert.strictEqual(output, expected);
      });
   
      it('Function should return a message if warehouse is empty', () => {
        assert.strictEqual(warehouse.revision(), 'The warehouse is empty');
      });
    });
    //---------------------------------------------------------------------------------------------
    describe('scrapeAProduct()', () => {
      it('Function should throw an error when trying to scrape unexisting product', () => {
        assert.throw(() => warehouse.scrapeAProduct('Banica', 200), 'Banica do not exists');
      });

      it("Function should subtract product's quantity with the passed one", () => {
        let foods = warehouse.addProduct('Food', 'Banica', 200);
        warehouse.scrapeAProduct('Banica', 150);
        assert.strictEqual(foods.Banica, 50);
      });

      it("Function should set quantity to 0 when trying to scrape more than available", () => {
        let foods = warehouse.addProduct('Food', 'Banica', 200);
        warehouse.scrapeAProduct('Banica', 2000);
        assert.strictEqual(foods.Banica, 0);
      });
    });
  });
});