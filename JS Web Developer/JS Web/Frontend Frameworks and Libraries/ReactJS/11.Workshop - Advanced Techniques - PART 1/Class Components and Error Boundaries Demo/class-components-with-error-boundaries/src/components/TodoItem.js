import { Component } from "react";

import ListGroup from 'react-bootstrap/ListGroup';
import Button from 'react-bootstrap/Button';

export default class TodoItem extends Component {
  componentDidMount() {
    console.log(`componentDidMount - ${this.props.label}`);
  }

  componentDidUpdate() {
    console.log(`componentDidUpdate - ${this.props.label}`);
  }

  componentWillUnmount() {
    console.log(`componentWillUnmount - ${this.props.label}`);
  };

  render() {
    return (
      <>
        <ListGroup.Item>
          <span
            onClick={() => this.props.onClick(this.props.id)}
            style={{ textDecoration: this.props.isCompleted ? 'line-through' : '' }}
          >
            {this.props.label}
          </span>
          <Button variant="danger" onClick={() => this.props.onDelete(this.props.id)}>Delete</Button>
        </ListGroup.Item>
      </>
    );
  }
}