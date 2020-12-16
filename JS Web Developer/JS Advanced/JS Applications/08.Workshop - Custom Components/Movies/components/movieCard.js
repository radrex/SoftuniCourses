import { html, render } from 'https://unpkg.com/lit-html?module';

const template = (context) => html`
  <div class="card mb-4">
    <img class="card-img-top" src="${context.data.imageUrl}" alt="${context.data.title}"
      width="400">
    <div class="card-body">
      <h4 class="card-title">${context.data.title}</h4>
    </div>
    <div class="card-footer">
      <a href="/details/${context.data.id}"><button type="button" class="btn btn-info">Details</button></a>
    </div>
  </div>
`;

class MovieCard extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.render();
  }

  render() {
    render(template(this), this, { eventContext: this });
  }
}

export default MovieCard;
