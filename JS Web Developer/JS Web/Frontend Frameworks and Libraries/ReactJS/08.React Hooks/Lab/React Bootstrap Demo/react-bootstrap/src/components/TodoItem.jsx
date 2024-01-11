import { ListGroup } from 'react-bootstrap';

export const TodoItem = ({ text, isCompleted }) => {
  return (
    <ListGroup.Item action>
      {text}
    </ListGroup.Item>
  );
};