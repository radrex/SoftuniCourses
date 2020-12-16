import { html, render } from 'https://unpkg.com/lit-html?module';
import { getMovies } from '../services/movieService.js';

const template = (context) => html`
  <h1 class="text-center">Movies</h1>
  <section>
    <a href="/create" class="btn btn-warning">Add Movie</a>
    <form class="search float-right">
      <label>Search: </label>
      <input type="text">
      <input type="submit" class="btn btn-info" value="Search">
    </form>
  </section>
  <div class=" mt-3 ">
    <div class="row d-flex d-wrap">
      <div class="card-deck d-flex justify-content-center">
        ${context.movies.map(movie => html`<movie-card .data=${movie}></movie-card>`)}
      </div>
    </div>
  </div>
`;

class Movies extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    getMovies().then(movies => {
      this.movies = movies;
      this.render();
    });
  }

  render() {
    render(template(this), this, { eventContext: this });
  }
}

export default Movies;
