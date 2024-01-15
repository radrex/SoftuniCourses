import { Component } from 'react';

import ListGroup from 'react-bootstrap/ListGroup';
import TodoItem from './TodoItem';

export default class TodoList extends Component {
  render() {
    return (
      <ListGroup>
        {this.props.todos.map(todo =>
          <TodoItem
            key={todo.id}
            onClick={this.props.onTodoClick}
            onDelete={this.props.onTodoDelete}
            {...todo}
          />
        )}
      </ListGroup>
    );
  }
}