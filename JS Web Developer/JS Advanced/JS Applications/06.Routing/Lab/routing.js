import { html } from "./dom.js";

const routerMap = {
  '/furniture/all': () => {
      html.homeSection().style.display = 'block';
      Promise.all([
        fetch('./furnitureTemplate.hbs').then(x => x.text()),
        fetch('https://routing-4601c.firebaseio.com/Furniture.json').then(x => x.json()),
      ])
      .then(([templateRaw, furnitures]) => {
        let template = Handlebars.compile(templateRaw);
        html.homeSection().innerHTML = (template({ furnitures }));
      })
      .catch(err => console.log(err));
  },

  '/furniture/details': (id) => {
    if (id) {
      html.detailsSection().style.display = 'block'
      Promise.all([
        fetch('./detailsTemplate.hbs').then(x => x.text()),
        fetch(`https://routing-4601c.firebaseio.com/Furniture/${id}.json`).then(x => x.json()),
      ])
      .then(([templateRaw, furniture]) => {
        let template = Handlebars.compile(templateRaw);
        html.detailsSection().innerHTML = template(furniture);
      })
      .catch(err => console.log(err));
    } else {
      //TODO: visualize All products in details page
    }
  },

  '/furniture/create': () => html.createSection().style.display = 'block',
  '/profile': () => html.profileSection().style.display = 'block',
};

const renderPage = (pathname) => {
  [html.homeSection(), html.createSection(), html.detailsSection(), html.profileSection()].forEach(x => x.style.display = 'none');
  if (pathname.includes('/furniture/details/')) {
    let id = pathname.split('/').pop();
    routerMap['/furniture/details'](id);
  } else {
    routerMap[pathname]();
  }
}

export { renderPage };
