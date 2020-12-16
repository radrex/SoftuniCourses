import { html, render } from 'https://unpkg.com/lit-html?module';
import { getAuthData } from '../services/authService.js';
import { getMovie, likeMovie, deleteMovie } from '../services/movieService.js';

const template = (context) => html`
  <div class="container">
    <div class="row bg-light text-dark">
      <h1>Movie title: ${context.movie.title}</h1>

      <div class="col-md-8">
        <img class="img-thumbnail" src="${context.movie.imageUrl}" alt="${context.movie.title}">
      </div>
      <div class="col-md-4 text-center">
        <h3 class="my-3 ">Movie Description</h3>
        <p>${context.movie.description}</p>

        ${context.movie.creator === context.user.email
          ? html`        
              <a class="btn btn-danger" href="/" @click=${context.onDelete}>Delete</a>
              <a class="btn btn-warning" href="/edit/${context.location.params.id}">Edit</a>
          `
          : html`
              <a class="btn btn-primary" @click=${context.onLike}>Like</a>
              <span class="enrolled-span">Liked ${context.movie.likes}</span>
          `
        }
      </div>
    </div>
  </div>
`;

class MovieDetails extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.user = getAuthData();

    getMovie(this.location.params.id).then(movie => {
      this.movie = movie;
      this.render();
    });
  }

  onLike() {
    likeMovie(this.location.params.id).then(this.render());
  }

  onDelete() {
    deleteMovie(this.location.params.id);
  }

  render() {
    render(template(this), this, { eventContext: this });
  }
}

export default MovieDetails;
