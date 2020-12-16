const apiKey = 'AIzaSyCTXeDM17YcHyac_3QoyiurPx7SoN2G-Fo';
const baseURL = 'https://workshopspa-630ba.firebaseio.com';

const apiEndpoints = {
  register: `https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=${apiKey}`,
  login: `https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${apiKey}`,
}

function register(email, password) {
  fetch(apiEndpoints.register, {
    method: 'POST',
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify({ email, password }),
  })
  .catch(err => console.log(err));
}

async function login(email, password) {
  let response = await fetch(apiEndpoints.login, {
    method: 'POST',
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify({ email, password }),
  })
  .then(x => x.json());

  localStorage.setItem('auth', JSON.stringify(response));
}

function logout() {
  localStorage.removeItem('auth');
}

function getAuthData() {
  let data = JSON.parse(localStorage.getItem('auth'));
  if (data) {
    return { isAuthenticated: Boolean(data.idToken), email: data.email };
  }

  return {isAuthenticated: false};
}

export { register, login, logout, getAuthData };