const app = Sammy('#main', function() {
  this.use('Handlebars', 'hbs'); // Specify Template Engine and its extension so it can compile

  //--------------------- HOME ---------------------
  this.get('/home', async function(context) {
    const auth = localStorage.getItem('auth');  
    if (auth) { // Check if logged through localStorage
      const { uid, email } = JSON.parse(auth);
      context.isLoggedIn = true; 
      context.email = email;
      context.shoes = [];

      await firebase.firestore().collection("shoes").get().then(res => {
        res.forEach(doc => context.shoes.push({id: doc.id, ...doc.data()}));
      });
    } 

    this.loadPartials({ // Do it only when our template contains partials
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
      'shoeCard': '../templates/home/shoeCard.hbs',
    })
    .then(function() {
      this.partial('../templates/home/home.hbs'); // After partials have been loaded, load the main template
    });
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
    let emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!emailRegex.test(email) || password === '' || password !== repeatPassword) {
      displayError('Invalid email or password.');
    } else {
      firebase.auth().createUserWithEmailAndPassword(email, password)
      .then(user => {
        const { user: { uid, email } } = user;
        localStorage.setItem('auth', JSON.stringify({ uid, email }));
        this.redirect('/home');
      })
      .then(displayInfo('Registered successfully.'))
      .catch(err => console.log(err));
    }
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

    if (email === '' || password === '') {
      displayError('Invalid email or password.')
    } else {
      firebase.auth().signInWithEmailAndPassword(email, password)
      .then(user => {
        const { user: { uid, email } } = user;
        localStorage.setItem('auth', JSON.stringify({ uid, email }));
        this.redirect('/home')
      })
      .then(displayInfo('Logged in successfully'))
      .catch(err => console.log(err));
    }
  });

  //-------------------- LOGOUT ---------------------
  this.get('/logout', function(context) {
    firebase.auth().signOut()
      .then(localStorage.removeItem('auth'))
      .then(this.redirect('/login'))
      .then(displayInfo('Logged out successfully.'))
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

    if (name === '' || price === '' || imageUrl === '' || description === '' || brand === '') {
      displayError('Please fill all fields.')
    } else {
      firebase.firestore().collection('shoes').add({
        name, price, imageUrl, description, brand,
        creator: JSON.parse(localStorage.getItem('auth')).email,
        buyers: [],
      })
      .then(this.redirect('/home'))
      .then(displayInfo('Offer created successfully.'))
      .catch(err => console.log(err));
    }
  });
  
  //-------------------- DETAILS ---------------------
  this.get('/details/:id', async function(context) {
    const auth = localStorage.getItem('auth');  
    if (auth) {
      const { uid, email } = JSON.parse(auth);
      context.isLoggedIn = true; 
      context.email = email;
      context.id = context.params.id;
      await firebase.firestore().collection('shoes').doc(context.id).get().then(res => {
        context.shoeData = res.data();
      });

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

    /* CAN'T DECIDE WHICH ONE IS BETTER
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
    */
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
    }, { merge: true }).then(this.redirect(`/details/${id}`))
                       .then(displayInfo('Offer edited successfully.'))
                       .catch(err => console.log(err));
  });

  //-------------------- DELETE ---------------------
  this.get('/delete/:id', function(context) {
    firebase.firestore().collection('shoes').doc(context.params.id)
      .delete()
      .then(this.redirect('/home'))
      .then(displayInfo('Offer deleted successfully.'))
      .catch(err => console.log(err));
  });

  //-------------------- BUY ---------------------
  this.get('/buy/:id', async function(context) {
    const auth = localStorage.getItem('auth');
    if (auth) {
      const { uid, email } = JSON.parse(auth);
      context.isLoggedIn = true; 
      context.email = email;
      context.id = context.params.id;

      let shoeData;
      await firebase.firestore().collection('shoes').doc(context.id).get().then(res => {
        shoeData = res.data();
      });
      shoeData.buyers.push(email);

      await firebase.firestore().collection('shoes').doc(context.id).set(shoeData)
       .then(this.redirect(`/details/${context.id}`))
       .then(displayInfo('You just bought a pair of cool shoes. Happy running!'))
       .catch(err => console.log(err));
    }
  });
});

(() => {  // Initial template load (first, when page loads)
  app.run('/home');
})();

function displayError(message) {
  let errorBox = document.getElementById('errorBox');
  errorBox.textContent = message;
  errorBox.style.display = 'block';
  setTimeout(() => { errorBox.textContent = ''; errorBox.style.display = 'none'; }, 1500);
}

function displayInfo(message) {
  let infoBox = document.getElementById('infoBox');
  infoBox.textContent = message;
  infoBox.style.display = 'block';

  setTimeout(() => { infoBox.textContent = ''; infoBox.style.display = 'none'; }, 1500);
}