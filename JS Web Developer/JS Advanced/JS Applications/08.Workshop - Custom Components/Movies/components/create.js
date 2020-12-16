import { Router } from 'https://unpkg.com/@vaadin/router';
import { html, render } from 'https://unpkg.com/lit-html?module';
import { getAuthData } from '../services/authService.js';
import { addMovie } from "../services/movieService.js";

const template = (context) => html`
  <form class="text-center border border-light p-5" action="#" method="POST" @submit=${context.addNewMovie}>
    <h1>Add Movie</h1>
    <div class="form-group">
      <label for="title">Movie Title</label>
      <input type="text" class="form-control" placeholder="Title" name="title" value="">
    </div>
    <div class="form-group">
      <label for="description">Movie Description</label>
      <textarea class="form-control" placeholder="Description" name="description"></textarea>
    </div>
    <div class="form-group">
      <label for="imageUrl">Image url</label>
      <input type="text" class="form-control" placeholder="Image Url" name="imageUrl" value="">
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
  </form>
`;

class Create extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.user = getAuthData();
    this.render();
  }

  render() {
    render(template(this), this, { eventContext: this });
  }

  addNewMovie(evt) {
    evt.preventDefault();

    let formData = new FormData(evt.target);
    let title = formData.get('title');
    let description = formData.get('description');
    let imageUrl = formData.get('imageUrl');

    addMovie(title, description, imageUrl, this.user.email).then(Router.go('/'));
  }
}

export default Create;
