function Spy(target, method) {
  let originalFunction = target[method];
  let result = {
    count: 0,
  }

  target[method] = function() {
    result.count++;
    return originalFunction.apply(this, arguments);
  }

  return result;
}

// Don't copy the code below in judge, you won't get any points, just the code above
let obj = {
  method: () => "invoked"
}

let spy = Spy(obj,"method");

obj.method();
obj.method();
obj.method();

console.log(spy) // { count: 3 }