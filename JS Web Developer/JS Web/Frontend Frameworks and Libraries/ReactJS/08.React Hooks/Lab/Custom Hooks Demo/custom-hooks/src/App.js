import 'bootstrap/dist/css/bootstrap.min.css';

import { Header } from './components/Header';
import { TodoList } from './components/TodoList';
import { AddTodoModal } from './components/AddTodoModal';

import { useState, useEffect } from 'react';

const baseUrl = 'http://localhost:3030/jsonstore/todos';

function App() {
  const [todos, setTodos] = useState([]);
  const [showAddTodo, setShowAddTodo] = useState(false);

  useEffect(() => {
    fetch(baseUrl)
      .then(res => res.json())
      .then(result => {
        setTodos(Object.values(result));
      });
  }, []);

  const onTodoAddSubmit = async (values) => {
    const response = await fetch(baseUrl, {
      method: 'POST',
      headers: {
        'content-type': 'application/json',
      },
      body: JSON.stringify(values),
    });

    const result = await response.json();
    setShowAddTodo(false);
    setTodos(state => [...state, result]);
  };

  const onTodoAddClick = () => {
    setShowAddTodo(true);
  }

  const onTodoAddClose = () => {
    setShowAddTodo(false);
  };

  const onTodoDeleteClick = async (todoId) => {
    const response = await fetch(`${baseUrl}/${todoId}`, {
      method: 'DELETE',
    });

    setTodos(state => state.filter(x => x._id !== todoId));
  };

  return (
    <div>
      <Header />
      <TodoList todos={todos} onTodoAddClick={onTodoAddClick} onTodoDeleteClick={onTodoDeleteClick} />

      <AddTodoModal show={showAddTodo} onTodoAddSubmit={onTodoAddSubmit} onTodoAddClose={onTodoAddClose} />
    </div>
  );
}

export default App;
