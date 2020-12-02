import { renderer } from "./rendering.js";

const navigate = {
  '/home': () => renderer.renderHomePage(),
  '/register': () => renderer.renderRegisterPage(),
  '/login': () => renderer.renderLoginPage(),
  '/logout': () => renderer.renderHomePage(),
  '/movies/add': () => renderer.renderAddMoviePage(),
  '/details': (id) => renderer.renderDetailsPage(id),
  '/edit': (id) => renderer.renderEditPage(id),
};

const initialLoad = (pathname) => {
  window.history.replaceState({}, '', pathname); // set initial state in order for the first backwards to work
  window.addEventListener('popstate', function(evt) { // forwards/backwards (pops the last state, changes URI pathname)
    if (evt.state !== null) { // if not null, then render the new URI pathname
      navigate[location.pathname]();
    }
  });
  navigate[pathname]();
};

export { initialLoad, navigate };