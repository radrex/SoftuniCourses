import { ListGroup, Button } from 'react-bootstrap';

import { useContext } from 'react';
import { TodoContext } from '../contexts/todoContext';

export const TodoItem = ({
  _id,
  text,
  isCompleted,
}) => {
  const { onTodoDeleteClick, onTodoClick } = useContext(TodoContext);

  return (
    <ListGroup.Item action style={{ display: 'flex', justifyContent: 'space-between' }} onClick={() => onTodoClick(_id)}>
      <p style={{ textDecoration: isCompleted ? 'line-through' : 'none' }}>
        {text}
      </p>
      <Button variant="dark" onClick={() => onTodoDeleteClick(_id)}>X</Button>
    </ListGroup.Item>
  );
};