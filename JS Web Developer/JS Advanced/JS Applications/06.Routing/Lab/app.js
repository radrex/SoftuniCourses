import { html } from "./dom.js";
import { renderPage } from "./routing.js";

window.history.replaceState({}, '', location.href); // set initial state in order for the first backward to work
renderPage(location.pathname); // initial load (refresh)
window.addEventListener('popstate', function (evt) {  // forwards/backwards
  if (evt.state !== null) {
    renderPage(location.pathname);
  }
});

html.siteNav().addEventListener('click', navigateMenu);
html.createForm().addEventListener('submit', createFurniture);
html.homeSection().addEventListener('click', showProductDetails);

function navigateMenu(evt) {
  evt.preventDefault();
  if (evt.target && evt.target.nodeName === 'A') {
    if (evt.target.pathname === location.pathname) {  // clicked on same page, dont push new state, modify current
      history.replaceState({}, '', location.pathname);
    } else {
      history.pushState({}, '', evt.target.href);
    }

    renderPage(location.pathname);
  }
}

function createFurniture(evt) {
  evt.preventDefault();
  let furniture = {
    make: html.makeInput().value,
    price: html.priceInput().value,
    model: html.modelInput().value,
    image: html.imageInput().value,
    year: html.yearInput().value,
    material: html.materialInput().value,
    description: html.descriptionInput().value,
  };

  let isFurnitureValid = (furniture) => {
    if (furniture.make.length < 4) return false;
    if (furniture.model.length < 4) return false;
    if (furniture.year < 1950 || furniture.year > 2050) return false;
    if (furniture.description.length <= 10) return false;
    if (furniture.price < 0) return false;
    if (furniture.image === '') return false;

    return true;
  }

  if (isFurnitureValid(furniture)) {
    fetch('https://routing-4601c.firebaseio.com/Furniture.json', {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify(furniture),
    })
    .then(x => {
      history.pushState({}, '', '/furniture/all');
      renderPage('/furniture/all');
    })
    .catch(err => console.log(err));
  }
}

function showProductDetails(evt) {
  evt.preventDefault();
  if (evt.target && evt.target.nodeName === 'A' && evt.target.textContent === 'Details') {
    history.pushState({}, '', evt.target.href);
    renderPage(location.pathname)
  }
}