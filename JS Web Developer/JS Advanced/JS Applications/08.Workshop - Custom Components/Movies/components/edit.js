import { Router } from 'https://unpkg.com/@vaadin/router';
import { html, render } from 'https://unpkg.com/lit-html?module';
import { getMovie, editMovie } from "../services/movieService.js";

const template = (context) => html`
  <form class="text-center border border-light p-5" action="#" method="POST" @submit=${context.editOldMovie}>
    <h1>Edit Movie</h1>
    <div class="form-group">
      <label for="title">Movie Title</label>
      <input type="text" class="form-control" placeholder="Movie Title" value="${context.movie.title}" name="title">
    </div>
    <div class="form-group">
      <label for="description">Movie Description</label>
      <textarea class="form-control" placeholder="Movie Description..." name="description">${context.movie.description}</textarea>
    </div>
    <div class="form-group">
      <label for="imageUrl">Image url</label>
      <input type="text" class="form-control" placeholder="Image Url" value="${context.movie.imageUrl}" name="imageUrl">
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
  </form>
`;

class Edit extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    getMovie(this.location.params.id).then(movie => {
      this.movie = movie;
      this.render();
    });
  }

  render() {
    render(template(this), this, { eventContext: this });
  }

  editOldMovie(evt) {
    evt.preventDefault();

    let formData = new FormData(evt.target);
    let title = formData.get('title');
    let description = formData.get('description');
    let imageUrl = formData.get('imageUrl');
    editMovie(this.location.params.id, title, description, imageUrl).then(Router.go('/'));
  }
}

export default Edit;
