import { useEffect, useState } from "react";

function App() {
  const [username, setUsername] = useState('Pesho');

  // This will change the username using the React state after 3 seconds to 'Gosho', but it won't change it in the browser DOM, just in vDOM.
  useEffect(() => {
    setTimeout(() => {
      setUsername('Gosho');
    }, 3000);
  }, []);

  const onUsernameChange = (e) => {
    console.log(e.target.value);
  };

  // const onSubmitClick = (e) => {
  //   e.preventDefault();
  //   console.log(e.target.parentElement.previousSibling.children[1].value);
  // };

  const onSubmit = (e) => {
    e.preventDefault();

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);
    const username = formData.get('username');

    console.log(username);
  };

  return (
    <form onSubmit={onSubmit}>
      <div>
        <label htmlFor="username">Username</label>
        <input 
          type="text"
          name="username"
          id="username"
          defaultValue={username}
          onChange={onUsernameChange}
        />
      </div>
      <div>
        <input
          type="submit"
          value="Send"
          // onClick={onSubmitClick}
        />
      </div>
    </form>
  );
}

export default App;
