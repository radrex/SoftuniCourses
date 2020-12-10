import { authService, moviesService } from "./services.js";
import { navigate } from "./routing.js";

const html = {
  container: () => document.getElementById('container'),
  nav: () => document.getElementById('nav'),
  addMovieBtn: () => document.getElementById('add-movie-btn'),
  registerForm: () => document.getElementById('register-form'),
  loginForm: () => document.getElementById('login-form'),
  addMovieForm: () => document.getElementById('add-movie-form'),
  editMovieForm: () => document.getElementById('edit-movie-form'),
  moviesContainer: () => document.getElementById('movies-container'),
  detailsContainer: () => document.getElementById('details-container'),
};

const renderer = {
  renderHomePage() {
    Promise.all([
      fetch('../templates/home/home.hbs').then(x => x.text()),
      fetch('../templates/common/nav.hbs').then(x => x.text()),
      fetch('../templates/common/footer.hbs').then(x => x.text()),
      fetch('../templates/home/movie.hbs').then(x => x.text()),
      moviesService.getMovies(),
    ])
    .then(([templateRaw, navPartialRaw, footerPartialRow, movieCardPartialRaw, moviesData]) => {
      Handlebars.registerPartial('nav', navPartialRaw);
      Handlebars.registerPartial('footer', footerPartialRow);
      Handlebars.registerPartial('movie', movieCardPartialRaw);
  
      let template = Handlebars.compile(templateRaw);

      let templateData = {};
      const auth = authService.getAuthData();
      if (auth) {
        templateData.isLoggedIn = true;
        templateData.email = auth.email;
        templateData.movies = moviesData;
      }

      html.container().innerHTML = template(templateData);
      handleEvtsAndState();
    });
  },
  renderRegisterPage() {
    Promise.all([
      fetch('../templates/register/register.hbs').then(x => x.text()),
      fetch('../templates/common/nav.hbs').then(x => x.text()),
      fetch('../templates/common/footer.hbs').then(x => x.text()),
    ])
    .then(([templateRaw, navPartialRaw, footerPartialRow]) => {
      Handlebars.registerPartial('nav', navPartialRaw);
      Handlebars.registerPartial('footer', footerPartialRow);
  
      let template = Handlebars.compile(templateRaw);
      html.container().innerHTML = template();
      handleEvtsAndState();
    });
  },
  renderLoginPage() {
    Promise.all([
      fetch('../templates/login/login.hbs').then(x => x.text()),
      fetch('../templates/common/nav.hbs').then(x => x.text()),
      fetch('../templates/common/footer.hbs').then(x => x.text()),
    ])
    .then(([templateRaw, navPartialRaw, footerPartialRow]) => {
      Handlebars.registerPartial('nav', navPartialRaw);
      Handlebars.registerPartial('footer', footerPartialRow);
  
      let template = Handlebars.compile(templateRaw);
      html.container().innerHTML = template();
      handleEvtsAndState();
    });
  },
  renderAddMoviePage() {
    Promise.all([
      fetch('../templates/movies/add.hbs').then(x => x.text()),
      fetch('../templates/common/nav.hbs').then(x => x.text()),
      fetch('../templates/common/footer.hbs').then(x => x.text()),
    ])
    .then(([templateRaw, navPartialRaw, footerPartialRow]) => {
      Handlebars.registerPartial('nav', navPartialRaw);
      Handlebars.registerPartial('footer', footerPartialRow);
      let template = Handlebars.compile(templateRaw);
      let templateData = {};
      const auth = authService.getAuthData();
      if (auth) {
        templateData.isLoggedIn = true;
        templateData.email = auth.email;
      }

      html.container().innerHTML = template(templateData);
      handleEvtsAndState();
    });
  },
  renderDetailsPage(id) {
    Promise.all([
      fetch('../templates/movies/details.hbs').then(x => x.text()),
      fetch('../templates/common/nav.hbs').then(x => x.text()),
      fetch('../templates/common/footer.hbs').then(x => x.text()),
      moviesService.getMovie(id),
    ])
    .then(([templateRaw, navPartialRaw, footerPartialRow, movieData]) => {
      Handlebars.registerPartial('nav', navPartialRaw);
      Handlebars.registerPartial('footer', footerPartialRow);
      let template = Handlebars.compile(templateRaw);
      let templateData = {};
      const auth = authService.getAuthData();
      if (auth) {
        templateData.isLoggedIn = true;
        templateData.email = auth.email;
        templateData.title = movieData.title;
        templateData.imageUrl = movieData.imageUrl;
        templateData.description = movieData.description;
        templateData.isCreator = movieData.creator === auth.email;
        templateData.movieId = id;
        templateData.likes = movieData.likes;
      }

      html.container().innerHTML = template(templateData);
      handleEvtsAndState();
    })
    .catch(err => console.log(err));
  },
  renderEditPage(id) {
    Promise.all([
      fetch('../templates/movies/edit.hbs').then(x => x.text()),
      fetch('../templates/common/nav.hbs').then(x => x.text()),
      fetch('../templates/common/footer.hbs').then(x => x.text()),
      moviesService.getMovie(id),
    ])
    .then(([templateRaw, navPartialRaw, footerPartialRow, movieData]) => {
      Handlebars.registerPartial('nav', navPartialRaw);
      Handlebars.registerPartial('footer', footerPartialRow);
      let template = Handlebars.compile(templateRaw);
      let templateData = {};
      const auth = authService.getAuthData();
      if (auth) {
        templateData.isLoggedIn = true;
        templateData.email = auth.email;
        templateData.title = movieData.title;
        templateData.imageUrl = movieData.imageUrl;
        templateData.description = movieData.description;
      }

      html.container().innerHTML = template(templateData);
      handleEvtsAndState();
    })
    .catch(err => console.log(err));
  }
};

function handleEvtsAndState() {
  html.nav().addEventListener('click', function (evt) {
    evt.preventDefault();
    if (evt.target && evt.target.nodeName === 'A') {
      if (evt.target.pathname === '/logout') {
        authService.logout();
        history.pushState({}, '', '/home');
      } else if (evt.target.pathname !== location.pathname) { // didn't click on the current url again
        history.pushState({}, '', evt.target.href);
      }
      navigate[location.pathname]();
    }
  });

  let addMovieBtn = html.addMovieBtn();
  if (addMovieBtn != null) {
    addMovieBtn.addEventListener('click', function(evt) {
      evt.preventDefault();
      history.pushState({}, '', evt.target.href);
      navigate[location.pathname]();
    });
  }

  let moviesContainer = html.moviesContainer();
  if (moviesContainer != null) {
    moviesContainer.addEventListener('click', function(evt) {
      if (evt.target && evt.target.nodeName === "BUTTON") {
        evt.preventDefault();
        history.pushState({}, '', evt.target.parentElement.href);
        let path = location.pathname.split('/');
        let id = path.pop();
        path = path.join('/');
        navigate[path](id);
      }
    });
  }

  if (location.pathname === '/register') {
    html.registerForm().addEventListener('submit', function(evt) {
      evt.preventDefault();
      let formData = new FormData(document.forms['register-form']);
      let email = formData.get('email');
      let password = formData.get('password');
      let repeatPassword = formData.get('repeatPassword');

      authService.register(email, password);
      history.pushState({}, '', '/login');
      navigate[location.pathname]();
    });
  } else if (location.pathname === '/login') {
    html.loginForm().addEventListener('submit', function(evt) {
      evt.preventDefault();
      let formData = new FormData(document.forms['login-form']);
      let email = formData.get('email');
      let password = formData.get('password');

      authService.login(email, password).then(x => {
        history.pushState({}, '', '/home');
        navigate[location.pathname]();
      });
    });
  } else if (location.pathname === '/movies/add') {
    html.addMovieForm().addEventListener('submit', function(evt){
      evt.preventDefault();
      let formData = new FormData(document.forms['add-movie-form']);
      let title = formData.get('title');
      let description = formData.get('description');
      let imageUrl = formData.get('imageUrl');

      const creator = authService.getAuthData().email;
      moviesService.addMovie(title, description, imageUrl, creator);
      // clear values, show notification

      history.pushState({}, '', '/home');
      navigate[location.pathname]();
    });
  } else if (location.pathname.includes('details')) {
    html.detailsContainer().addEventListener('click', function(evt) {
      evt.preventDefault();
      if (evt.target && evt.target.nodeName === "A") {
        let movieId = evt.target.href.split('/').pop();
        if (evt.target.textContent === 'Delete') {
          moviesService.deleteMovie(movieId);
          history.pushState({}, '', '/home');
          navigate[location.pathname]();
        } else if (evt.target.textContent === 'Edit') {
          history.pushState({}, '', evt.target.href);
          let path = location.pathname.split('/');
          let id = path.pop();
          path = path.join('/');
          navigate[path](id);
        } else if (evt.target.textContent === 'Like') {
          moviesService.likeMovie(movieId);
          history.pushState({}, '', '/home');
          navigate[location.pathname]();
        }
      }
    });
  } else if (location.pathname.includes('edit')) {
    html.editMovieForm().addEventListener('submit', function(evt) {
      evt.preventDefault();
      let id = location.pathname.split('/').pop();
      let formData = new FormData(document.forms['edit-movie-form']);
      let title = formData.get('title');
      let description = formData.get('description');
      let imageUrl = formData.get('imageUrl');

      moviesService.editMovie(id, title, description, imageUrl);
      history.pushState({}, '', '/home');
      navigate[location.pathname]();
    });
  }
}

export { html, renderer };