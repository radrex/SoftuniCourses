import React from 'react';

const Timer = (props) => {
  const [seconds, setSeconds] = React.useState(props.start);

  // Not good practice (useEffect is better), but will use it for the demo
  setTimeout(() => {
    setSeconds(state => state + 1);
  }, 1000);

  return (
    <div>
      <h2>Timer</h2>
      Time: {seconds}s.
    </div>
  );
};

export default Timer;