import { useEffect, useState } from 'react';

import AddNewTodoButton from './AddNewTodoItem';
import LoadingSpinner from './LoadingSpinner';
import TodoTable from './TodoTable';

function Main() {
  const [todoItems, setTodoItems] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    fetch('http://localhost:3030/jsonstore/todos') // make sure you run the server as well as the app first, otherwise fetch won't work
      .then(res => res.json())
      .then(data => {
        setTodoItems(Object.values(data));
        setIsLoading(false);
      });
  }, []);

  const addTodoItem = () => {
    const lastTodoItemId = todoItems[todoItems.length - 1]._id;
    const text = prompt('Task name:');
    const newTodoItem = { _id: lastTodoItemId + 1, text, isCompleted: false };
    setTodoItems(state => [...state, newTodoItem]);
  };

  const toggleTodoStatus = (id) => {
    setTodoItems(state => state.map(x => x._id === id ? ({...x, isCompleted: !x.isCompleted}) : x));
  };

  return (
    <main className="main">
      <section className="todo-list-container">
        <h1>Todo List</h1>
        <AddNewTodoButton addTodoItem={addTodoItem}/>

        <div className="table-wrapper">
          { isLoading ? <LoadingSpinner /> : <TodoTable todoItems={todoItems} toggleTodoStatus={toggleTodoStatus} /> }
        </div>
      </section>
    </main>
  );
}

export default Main;