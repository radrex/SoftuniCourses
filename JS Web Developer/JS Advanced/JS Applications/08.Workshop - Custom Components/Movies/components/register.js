import { html, render } from 'https://unpkg.com/lit-html?module';
import { register } from "../services/authService.js";

const template = (context) => html`
  <form class="text-center border border-light p-5" action="#" method="post" @submit=${context.registerUser}>
    <div class="form-group">
      <label for="email">Email</label>
      <input type="email" class="form-control" placeholder="Email" name="email" value="">
    </div>
    <div class="form-group">
      <label for="password">Password</label>
      <input type="password" class="form-control" placeholder="Password" name="password" value="">
    </div>
  
    <div class="form-group">
      <label for="repeatPassword">Repeat Password</label>
      <input type="password" class="form-control" placeholder="Repeat-Password" name="repeatPassword" value="">
    </div>
  
    <button type="submit" class="btn btn-primary">Register</button>
  </form>
`;

class Register extends HTMLElement {
  constructor() {
    super();
    // this.registerUser = this.registerUser.bind(this); // same as { eventContext: this } in render
  }

  connectedCallback() {
    this.render();
  }

  render() {
    render(template(this), this, { eventContext: this });
  }

  registerUser(evt) {
    evt.preventDefault();

    let formData = new FormData(evt.target);
    let email = formData.get('email');
    let password = formData.get('password');
    let repeatPassword = formData.get('repeatPassword');

    // TODO: Add validation and notification
    register(email, password);  //.then(res => notify successfull registration) redirect, catch
  }
}

export default Register;
