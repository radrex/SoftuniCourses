import { Component } from 'react';

import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';

import { TodoContext } from '../contexts/TodoContext';

export default class Header extends Component {
  render() {
    if (Math.random() < 0.5) {
      throw { message: `Failed to redner` }
    }

    return (
      <TodoContext.Consumer>
        {({ name }) => (
          <Navbar bg="light" expand="lg">
            <Container>
              <Navbar.Brand href="#home">Class Components</Navbar.Brand>
              <Navbar.Toggle aria-controls="basic-navbar-nav" />
              <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="me-auto">
                  <Nav.Link href="#home">Home</Nav.Link>
                  <Nav.Link href="#link">Link</Nav.Link>
                  <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                    <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                    <NavDropdown.Item href="#action/3.2">
                      Another action
                    </NavDropdown.Item>
                    <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                    <NavDropdown.Divider />
                    <NavDropdown.Item href="#action/3.4">
                      Separated link
                    </NavDropdown.Item>
                  </NavDropdown>
                  <span>{name}</span>
                </Nav>
              </Navbar.Collapse>
            </Container>
          </Navbar>
        )}
      </TodoContext.Consumer>
    );
  }
}
