const app = Sammy('#main', function() {
  this.use('Handlebars', 'hbs'); // Specify Template Engine and its extension so it can compile

  //--------------------- HOME ---------------------
  this.get('/home', function(context) {
    const auth = localStorage.getItem('auth');  
    if (auth) { // Check if logged through localStorage
      const { uid, email } = JSON.parse(auth);
      context.isLoggedIn = true; 
      context.email = email;
      context.shoes = [];

      firebase.firestore().collection("shoes").get().then(res => {
        res.forEach(doc => context.shoes.push({id: doc.id, ...doc.data()}));

        this.loadPartials({ // Do it only when our template contains partials
          'header': '../templates/common/header.hbs',
          'footer': '../templates/common/footer.hbs',
          'shoeCard': '../templates/home/shoeCard.hbs',
        })
        .then(function() {
          this.partial('../templates/home/home.hbs'); // After partials have been loaded, load the main template
        });
      });
    } else {
      this.loadPartials({ // Do it only when our template contains partials
        'header': '../templates/common/header.hbs',
        'footer': '../templates/common/footer.hbs',
        'shoeCard': '../templates/home/shoeCard.hbs',
      })
      .then(function() {
        this.partial('../templates/home/home.hbs'); // After partials have been loaded, load the main template
      });
    }
  });

  //-------------------- REGISTER ---------------------
  this.get('/register', function() {
    this.loadPartials({
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
    })
    .then(function() {
      this.partial('../templates/register/register.hbs');
    });
  });
  this.post('/register', function(context) {
    // these properties come from context.params, which come from input's 'name' attribute
    const { email, password, repeatPassword } = context.params;

    //check if passwords are the same

    firebase.auth().createUserWithEmailAndPassword(email, password)
      .then(user => {
        const { user: { uid, email } } = user;
        localStorage.setItem('auth', JSON.stringify({ uid, email }));
        this.redirect('/home');
      })
      .catch(err => console.log(err));
  });

  //-------------------- LOGIN ---------------------
  this.get('/login', function() {
    this.loadPartials({
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
    })
    .then(function() {
      this.partial('../templates/login/login.hbs');
    });
  });
  this.post('/login', function(context) {
    const { email, password } = context.params;

    firebase.auth().signInWithEmailAndPassword(email, password)
      .then(user => {
        const { user: { uid, email } } = user;
        localStorage.setItem('auth', JSON.stringify({ uid, email }));
        this.redirect('/home');
      })
      .catch(err => console.log(err));
  });

  //-------------------- LOGOUT ---------------------
  this.get('/logout', function(context) {
    firebase.auth().signOut()
      .then(x => {
        localStorage.removeItem('auth');
        context.redirect('/login');
      })
      .catch(err => console.log(err));
  });

  //-------------------- CREATE ---------------------
  this.get('/create', function() {
    this.loadPartials({
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
    })
    .then(function() {
      this.partial('../templates/shoes/create.hbs');
    });
  });
  this.post('/create', function(context) {
    const { name, price, imageUrl, description, brand } = context.params;
    //validate

    firebase.firestore().collection('shoes').add({
      name, price, imageUrl, description, brand,
      creator: JSON.parse(localStorage.getItem('auth')).email,
      buyers: [],
    })
    .then(x => {
      this.redirect('/home');
    })
    .catch(err => console.log(err));
  });
  
  //-------------------- DETAILS ---------------------
  this.get('/details/:id', function(context) {
    firebase.firestore().collection('shoes').doc(context.params.id).get().then(res => {
      const auth = localStorage.getItem('auth');  
      if (auth) { // Check if logged through localStorage
        const { uid, email } = JSON.parse(auth);
        context.isLoggedIn = true; 
        context.email = email;
        context.id = context.params.id;
        context.shoeData = res.data();
        context.isCreator = email === context.shoeData.creator;
        context.isBought = context.shoeData.buyers.some(mail => mail === email);
      }

      this.loadPartials({
        'header': '../templates/common/header.hbs',
        'footer': '../templates/common/footer.hbs',
      })
      .then(function() {
        this.partial('../templates/shoes/details.hbs');
      });
    });
  });

  //-------------------- EDIT ---------------------
  this.get('/edit/:id', function(context) {
    firebase.firestore().collection('shoes').doc(context.params.id).get().then(res => {
      const auth = localStorage.getItem('auth');  
      if (auth) { // Check if logged through localStorage
        const { uid, email } = JSON.parse(auth);
        context.isLoggedIn = true; 
        context.email = email;
        context.id = context.params.id;
        context.shoeData = res.data();
      }

      this.loadPartials({
        'header': '../templates/common/header.hbs',
        'footer': '../templates/common/footer.hbs',
      })
      .then(function() {
        this.partial('../templates/shoes/edit.hbs');
      });
    });
  });
  this.put('/edit/:id', function(context) {
    const { id, name, price, imageUrl, description, brand } = context.params;

    firebase.firestore().collection('shoes').doc(context.params.id).set({
      name, price, imageUrl, description, brand
    }, { merge: true }).then(x => {
      this.redirect(`/details/${id}`);
    }).catch(err => console.log(err));
  });

  //-------------------- DELETE ---------------------
  this.get('/delete/:id', function(context) {
    firebase.firestore().collection('shoes').doc(context.params.id).delete().then(res => {
      this.redirect('/home');      
    }).catch(err => console.log(err));
  });

  //-------------------- BUY ---------------------
  this.get('/buy/:id', function(context) {
    firebase.firestore().collection('shoes').doc(context.params.id).get().then(res => {
      const auth = localStorage.getItem('auth');
      const { uid, email } = JSON.parse(auth);
      const shoeData = { ...res.data() };
      shoeData.buyers.push(email);
      return firebase.firestore().collection('shoes').doc(context.params.id).set(shoeData);

      // // doesnt redirect after update (can't return promise for some reason)
      // let buyers = shoeData.buyers;
      // return firebase.firestore().collection('shoes').doc(context.params.id).set({
      //   buyers
      // }, { merge: true })
    })
    .then(x => {
      this.redirect(`/details/${id}`);
    }).catch(err => console.log(err));
  });
  
  //---------------------------------------------
});

(() => {  // Initial template load (first, when page loads)
  app.run('/home');
})();
