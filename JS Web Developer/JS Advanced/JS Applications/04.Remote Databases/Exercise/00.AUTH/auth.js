const html = {
  createAccDiv: () => document.getElementsByClassName('create-account')[0],
  LoginDiv: () => document.getElementsByClassName('login')[0],
  loginButton: () => document.getElementById('login-button'),
  regButton: () => document.getElementById('register-button'),
  emailInput: () => document.getElementById('email-input'),
  emailLoginInput: () => document.getElementById('email-login-input'),
  passwordInput: () => document.getElementById('password-input'),
  passwordLoginInput: () => document.getElementById('password-login-input'),
  confirmPasswordInput: () => document.getElementById('confirm-password-input'),
  createAccButton: () => document.getElementById('create-account-button'),
  haveAccButton: () => document.getElementById('have-account-button'),
  errorMsg: () => document.getElementById('error-msg'),
  logOutForm: () => document.getElementsByClassName('logout')[0],
  logOutButton: () => document.getElementById('logout-button'),
}

html.regButton().addEventListener('click', registerUser)
html.loginButton().addEventListener('click', loginUser)
html.createAccButton().addEventListener('click', getLoginForm)
html.haveAccButton().addEventListener('click', getCreateAccountForm)
html.logOutButton().addEventListener('click', logOutUser)

function registerUser(e) {
  e.preventDefault()
  const email = html.emailInput().value;
  const pass = html.passwordInput().value;
  const confirmPass = html.confirmPasswordInput().value;
  if (pass !== confirmPass || pass.length < 6) {
    html.errorMsg().style.display = 'block';
    return;
  }
  html.errorMsg().style.display = 'none';
  firebase.auth().createUserWithEmailAndPassword(email, pass)
  .catch(e => console.log(e))
  cleanValues()
  window.alert(`You have create user with email: ${email}`)
  html.createAccDiv().style.display = 'none';
  html.LoginDiv().style.display = 'block';
}

function loginUser(e) {
  e.preventDefault()
  const email = html.emailLoginInput().value;
  const pass = html.passwordLoginInput().value;
  firebase.auth().signInWithEmailAndPassword(email, pass)
  .then(data => {
    window.alert(`You have logged in successfully.`)
    html.LoginDiv().style.display = 'none';
    html.logOutForm().style.display = 'block';
    cleanValues()
  })
  .catch(error => console.log(error));
}

function logOutUser(e) {
  e.preventDefault()
  firebase.auth().signOut()
  .then(data => {
    html.logOutForm().style.display = 'none';
    html.LoginDiv().style.display = 'block';
    window.alert(`You have logged out successfully.`)
  })
  .catch(e => console.log(e))
}

function getLoginForm(e) {
  e.preventDefault()
  html.createAccDiv().style.display = 'block';
  html.LoginDiv().style.display = 'none';
}

function getCreateAccountForm(e) {
  e.preventDefault()
  html.createAccDiv().style.display = 'none';
  html.LoginDiv().style.display = 'block';
}

function cleanValues() {
  html.emailInput().value = '';
  html.passwordInput().value = '';
  html.confirmPasswordInput().value = '';
  html.emailLoginInput().value = '';
  html.passwordLoginInput().value = '';
}