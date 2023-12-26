import React from "react";
import { Navbar, Nav, Container } from "react-bootstrap";
import LoginButton from "./LoginButton";
import LogoutButton from "./LogoutButton";

const NavigationBar: React.FC = () => {
  return (
    <Navbar bg="light" expand="lg">
      <Container>
        <Navbar.Brand href="#home">Lab5</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="/lab1">Lab1</Nav.Link>
            <Nav.Link href="/lab2">Lab2</Nav.Link>
            <Nav.Link href="/lab3">Lab3</Nav.Link>
          </Nav>
        </Navbar.Collapse>
        <LoginButton />
        <LogoutButton />
      </Container>
    </Navbar>
  );
};

export default NavigationBar;
