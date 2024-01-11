import { ListGroup, Button} from 'react-bootstrap';
import { TodoItem } from './TodoItem';

export const TodoList = ({
  todos,
  onTodoAddClick,
}) => {
  return (
    <div style={{ width: '50%', margin: '10px auto' }}>
      <h1>Todo List</h1>
      
      <ListGroup style={{marginBottom: '10px'}}>
        {todos.map(x => <TodoItem key={x._id} {...x} />)}
      </ListGroup>

      <Button variant="primary" onClick={onTodoAddClick}>Add</Button>
    </div>
  );
}