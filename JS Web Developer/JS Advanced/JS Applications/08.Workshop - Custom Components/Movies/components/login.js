import { Router } from 'https://unpkg.com/@vaadin/router';
import { html, render } from 'https://unpkg.com/lit-html?module';
import { login } from "../services/authService.js";

const template = (context) => html`
  <form class="text-center border border-light p-5" action="" method="POST" @submit=${context.loginUser}>
    <div class="form-group">
      <label for="email">Email</label>
      <input type="email" class="form-control" placeholder="Email" name="email" value="">
    </div>
    <div class="form-group">
      <label for="password">Password</label>
      <input type="password" class="form-control" placeholder="Password" name="password" value="">
    </div>
  
    <button type="submit" class="btn btn-primary">Login</button>
  </form>
`;


class Login extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.render();
  }

  render() {
    render(template(this), this, { eventContext: this });
  }

  loginUser(evt) {
    evt.preventDefault();

    let formData = new FormData(evt.target);
    let email = formData.get('email');
    let password = formData.get('password');

    // TODO: Add validation and notification
    login(email, password).then(Router.go('/'));  //.then(res => notify successfull registration) redirect, catch
  }
}

export default Login;
