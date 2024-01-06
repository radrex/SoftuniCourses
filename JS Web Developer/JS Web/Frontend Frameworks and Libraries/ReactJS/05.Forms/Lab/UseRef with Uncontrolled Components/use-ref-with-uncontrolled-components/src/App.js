import {  useState, useEffect, useRef } from "react";

function App() {
  const ref = useRef();

  const [values, setValues] = useState({
    username: 'Pesho',
  });

  useEffect(() => {
    ref.current.value = values.username;
  }, [values.username]);

  const onChangeHandler = (e) => {
    // Does the same thing as useEffect implementation above
    // console.log(ref.current.value);
    // if (e.target.name === 'username') {
    //   ref.current.value = e.target.value;
    // }
    setValues(state => ({...state, [e.target.name]: e.target.value}));
  };

  const onSubmitHandler = (e) => {
    e.preventDefault();
  };

  return (
    <form onSubmit={onSubmitHandler}>
      <div>
        <label htmlFor="username">Username</label>
        <input 
          type="text"
          name="username"
          id="username"
          value={values.username}
          onChange={onChangeHandler}
        />
      </div>

      <div>
        <label htmlFor="uncontrolled">Uncontrolled</label>
        <input type="text" name="uncontrolled" id="uncontrolled" ref={ref} />
      </div>

      <div>
        <input
          type="submit"
          value="Send"
        />
      </div>
    </form>
  );
}

export default App;
