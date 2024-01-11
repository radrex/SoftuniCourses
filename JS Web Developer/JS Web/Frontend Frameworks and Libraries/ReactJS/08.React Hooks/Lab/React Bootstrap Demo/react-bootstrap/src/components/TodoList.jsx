import { ListGroup } from 'react-bootstrap';
import { TodoItem } from './TodoItem';

export const TodoList = ({todos}) => {
  return (
    <div style={{ width: '50%', margin: '10px auto' }}>
      <h1>Todo List</h1>
      
      <ListGroup>
        {todos.map(x => <TodoItem key={x._id} {...x} />)}
      </ListGroup>
    </div>
  );
}