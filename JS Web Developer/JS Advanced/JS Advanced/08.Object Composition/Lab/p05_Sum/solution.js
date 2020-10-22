function getModel() {
  const model = (() => ({
    init(selector1, selector2, resultSelector) {
      model.num1 = document.querySelector(`${selector1}`);
      model.num2 = document.querySelector(`${selector2}`);
      model.result = document.querySelector(`${resultSelector}`);
    },
    add: () => model.action((a, b) => a + b),
    subtract: () => model.action((a, b) => a - b),
    action(operation) {
      const val1 = Number(model.num1.value);
      const val2 = Number(model.num2.value);
      model.result.value = operation(val1, val2);
    },
  }))();

  return model;
}
