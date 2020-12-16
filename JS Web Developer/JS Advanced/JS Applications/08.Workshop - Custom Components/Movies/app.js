import { Router } from 'https://unpkg.com/@vaadin/router';

import { logout } from './services/authService.js';
import Home from './components/home.js';
import Login from './components/login.js';
import Register from './components/register.js';
import Movies from './components/movies.js';
import MovieCard from './components/movieCard.js';
import MovieDetails from './components/movieDetails.js';
import Create from './components/create.js';
import Edit from './components/edit.js';

window.customElements.define('home-component', Home);
window.customElements.define('login-component', Login);
window.customElements.define('register-component', Register);
window.customElements.define('movies-component', Movies);
window.customElements.define('movie-card', MovieCard);
window.customElements.define('movie-details-component', MovieDetails);
window.customElements.define('create-movie-component', Create);
window.customElements.define('edit-movie-component', Edit);

const root = document.getElementById('root');
const router = new Router(root);

router.setRoutes([
  {path: '/', component: 'home-component'},
  {path: '/login', component: 'login-component'},
  {path: '/logout', action: (context, commands) => { logout(); return commands.redirect('/login'); }},
  {path: '/register', component: 'register-component'},
  {path: '/details/:id', component: 'movie-details-component'},
  {path: '/create', component: 'create-movie-component'},
  {path: '/edit/:id', component: 'edit-movie-component'},
]);
