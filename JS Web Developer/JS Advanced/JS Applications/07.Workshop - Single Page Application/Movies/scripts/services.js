const apiKey = 'AIzaSyCTXeDM17YcHyac_3QoyiurPx7SoN2G-Fo';
const baseURL = 'https://workshopspa-630ba.firebaseio.com';

const authService = {
  register(email, password) {
    fetch(`https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=${apiKey}`, {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify({ email, password }),
    })
    .catch(err => console.log(err));
  },

  async login(email, password) {
    let response = await fetch(`https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${apiKey}`, {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify({ email, password }),
    })
    .then(x => x.json());

    localStorage.setItem('auth', JSON.stringify(response));
    return response;
  },

  logout() {
    localStorage.removeItem('auth');
  },

  getAuthData() {
      return JSON.parse(localStorage.getItem('auth'));
  }
};

const moviesService = {
  addMovie(title, description, imageUrl, creator) {
    fetch(`${baseURL}/Movies.json`, {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify({ title, description, imageUrl, creator, likes: 0 }),
    })
    .catch(err => console.log(err));
  },

  async getMovies() {
    return await fetch(`${baseURL}/Movies.json`).then(x => x.json());
  },

  async getMovie(id) {
    return await fetch(`${baseURL}/Movies/${id}.json`).then(x => x.json());
  },

  deleteMovie(id) {
    fetch(`${baseURL}/Movies/${id}.json`, { method: 'DELETE' });
  },
   
  editMovie(id, title, description, imageUrl) {
    fetch(`${baseURL}/Movies/${id}.json`, {
      method: 'PATCH',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify({ title, description, imageUrl }),
    });
  },

  likeMovie(id) {
    fetch(`${baseURL}/Movies/${id}.json`)
      .then(res => res.json())
      .then(data => {
        let likes = data.likes + 1;
        fetch(`${baseURL}/Movies/${id}.json`, {
          method: 'PATCH',
          headers: { 'content-type': 'application/json' },
          body: JSON.stringify({ likes }),
        })
      });
  }
};

export { authService, moviesService };