import 'bootstrap/dist/css/bootstrap.min.css';
import { Header } from './components/Header';
import { TodoList } from './components/TodoList';

import { useState, useEffect } from 'react';

const baseUrl = 'http://localhost:3030/jsonstore/todos';

function App() {
  const [todos, setTodos] = useState([]);

  useEffect(() => {
    fetch(baseUrl)
      .then(res => res.json())
      .then(result => {
        setTodos(Object.values(result));
      });
  }, []);

  return (
    <div>
      <Header />
      <TodoList todos={todos} />
    </div>
  );
}

export default App;
