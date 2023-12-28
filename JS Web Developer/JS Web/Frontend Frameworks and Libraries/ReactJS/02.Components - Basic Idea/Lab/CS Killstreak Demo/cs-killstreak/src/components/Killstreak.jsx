import { useState } from "react";

const getTitle = (count) => {
  switch (count) {
    case 1:
      return 'First Blood';
    case 2:
      return 'Double Kill';
    case 3:
      return 'Tripple Kill';
    case 4:
      return 'Multi Kill';
    case 5:
      return 'Unstoppable';
    default:
      return 'Counter';
  }
};

const Killstreak = (props) => {
  const [counter, setCounter] = useState(0);

  const incrementCounterHanlder = () => {
    setCounter(oldCounter => oldCounter + 1);
  };

  const decrementCounterHandler = () => {
    setCounter(oldCounter => oldCounter - 1);
  };

  const clearCounterHanlder = () => {
    setCounter(0);
  };

  return (
    <div>
      <button onClick={decrementCounterHandler}>-</button>
      {props.canReset && <button onClick={clearCounterHanlder}>0</button>}
      {counter < 10 ? <button onClick={incrementCounterHanlder}>+</button> : null}

      <p style={{ fontSize: Math.max(counter, 1) / 2 + 'em' }}>
        {counter > 5 ? 'Godlike' : getTitle(counter)}: {counter}
      </p>
    </div>
  );
};

export default Killstreak;