const router = Sammy('#main', function() {
  this.use('Handlebars', 'hbs'); // Specify Template Engine and its extension so it can compile

  //--------------------- GET ACTIONS ---------------------
  this.get('/home', function(context) { // Route
    const userInfo = localStorage.getItem('userInfo');  
    if (userInfo) { // Check if logged through localStorage
      const { uid, email } = JSON.parse(userInfo);
      context.loggedIn = true; // attach prop for header.hbs
      context.email = email; // attach prop for header.hbs
    }

    this.loadPartials({ // Do it only when our template contains partials
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
    })
    .then(function() {
      this.partial('../templates/home/home.hbs'); // After partials have been loaded, load the main template
    });
  });

  this.get('/about', function(context) {
    const userInfo = localStorage.getItem('userInfo');  
    if (userInfo) {
      const { uid, email } = JSON.parse(userInfo);
      context.loggedIn = true;
      context.email = email;
    }

    this.loadPartials({
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
    })
    .then(function() {
      this.partial('../templates/about/about.hbs');
    });
  });

  this.get('/login', function() {
    this.loadPartials({
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
      'loginForm': '../templates/login/loginForm.hbs',
    })
    .then(function() {
      this.partial('../templates/login/loginPage.hbs');
    });
  });

  this.get('/register', function() {
    this.loadPartials({
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
      'registerForm': '../templates/register/registerForm.hbs',
    })
    .then(function() {
      this.partial('../templates/register/registerPage.hbs');
    });
  });

  this.get('/logout', function(context) {
    firebase.auth().signOut()
      .then(x => {
        localStorage.removeItem('userInfo');
        context.redirect('/home');
      })
      .catch(err => console.log(err));
  });
  
  this.get('/catalog', function(context) {
    const userInfo = localStorage.getItem('userInfo');  
    if (userInfo) {
      const { uid, email } = JSON.parse(userInfo);
      context.loggedIn = true;
      context.email = email;
    }

    //TODO: implement create team functionality

    this.loadPartials({
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
      'team': '../templates/catalog/team.hbs',
    })
    .then(function() {
      this.partial('../templates/catalog/teamCatalog.hbs');
    });
  });
  //-------------------- POST ACTIONS ---------------------
  this.post('/register', function(context) {
    // these properties come from context.params, which come from input's 'name' attribute
    const { email, password, repeatPassword } = context.params;
    
    if (password !== repeatPassword) {
      let errorBox = document.getElementById('errorBox');
      errorBox.textContent = 'Passwords should match each other';
      errorBox.style.display = 'block';

      setTimeout(() => { errorBox.textContent = ''; errorBox.style.display = 'none'; }, 2000);
      return;
    }

    //TODO: check password validity for firebase (at least 6 symbols)

    firebase.auth().createUserWithEmailAndPassword(email, password)
      .then(user => {
        this.redirect('/login');
      })
      .catch(err => console.log(err));
  });

  this.post('/login', function(context) {
    const { email, password } = context.params;

    firebase.auth().signInWithEmailAndPassword(email, password)
      .then(user => {
        const { user: { uid, email } } = user;
        localStorage.setItem('userInfo', JSON.stringify({ uid, email }));
        context.redirect('/home');
      })
      .catch(err => console.log(err));
  });
});

(() => {  // Initial template load (first, when page loads)
  router.run('/home');
})();
