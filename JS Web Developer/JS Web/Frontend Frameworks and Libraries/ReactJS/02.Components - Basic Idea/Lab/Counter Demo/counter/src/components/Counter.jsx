import { useState } from 'react';

const Counter = (props) => {
  const [counter, setCounter] = useState(0);

    const incrementCounterHanlder = (e) => {
        setCounter(oldCounter => oldCounter + 1);
    };

    const decrementCounterHandler = (e) => {
        setCounter(oldCounter => oldCounter - 1);
    };

    const clearCounterHanlder = (e) => {
        setCounter(0);
    };

  return (
    <div>
      <h3>Counter: {counter}</h3>
      <button onClick={decrementCounterHandler}>-</button>
      <button onClick={clearCounterHanlder}>0</button>
      <button onClick={incrementCounterHanlder}>+</button>
    </div>
  );
};

export default Counter;