const app = Sammy('#container', function() {
  this.use('Handlebars', 'hbs'); // Specify Template Engine and its extension so it can compile

  //--------------------- HOME ---------------------
  this.get('/home', async function(context) {
    const auth = localStorage.getItem('auth');
    if (auth) { // Check if logged through localStorage
      const { uid, email } = JSON.parse(auth);
      context.isLoggedIn = true;
      context.email = email;
      context.destinations = [];

      await firebase.firestore().collection("destinations").get().then(res => {
        res.forEach(doc => context.destinations.push({ id: doc.id, ...doc.data() }));
      });
    }

    this.loadPartials({ // Do it only when our template contains partials
      'nav': '../templates/common/nav.hbs',
      'footer': '../templates/common/footer.hbs',
      'destinationCard': '../templates/home/destinationCard.hbs',
    })
    .then(function () {
      this.partial('../templates/home/home.hbs'); // After partials have been loaded, load the main template
    });
  });
  //-------------------- REGISTER ------------------
  this.get('/register', function() {
    this.loadPartials({
      'nav': '../templates/common/nav.hbs',
      'footer': '../templates/common/footer.hbs',
    })
    .then(function () {
      this.partial('../templates/register/register.hbs');
    });
  });

  this.post('/register', function(context) {
    const { email, password, rePassword } = context.params;

    let regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (!regex.test(email) || password === '' || password !== rePassword) {
      displayError('Invalid email or password');
    } else {
      firebase.auth().createUserWithEmailAndPassword(email, password)
        .then(user => {
          const { user: { uid, email } } = user;
          localStorage.setItem('auth', JSON.stringify({ uid, email }));
          this.redirect('/home');
          displayInfo('User registration successful.');
        })
        .catch(err => displayError(err.message));
    }
  });
  //-------------------- LOGIN ---------------------
  this.get('/login', function() {
    this.loadPartials({
      'nav': '../templates/common/nav.hbs',
      'footer': '../templates/common/footer.hbs',
    })
    .then(function () {
      this.partial('../templates/login/login.hbs');
    });
  });

  this.post('/login', function(context) {
    const { email, password } = context.params;

    let regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (!regex.test(email) || password === '') {
      displayError('Invalid email or password');
    } else {
      firebase.auth().signInWithEmailAndPassword(email, password)
        .then(user => {
          const { user: { uid, email } } = user;
          localStorage.setItem('auth', JSON.stringify({ uid, email }));
          this.redirect('/home');
          displayInfo('Login successful.');
        })
        .catch(err => displayError(err.message));
    }
  });
  //-------------------- LOGOUT --------------------
  this.get('/logout', function() {
    firebase.auth().signOut()
      .then(() => {
        localStorage.removeItem('auth');
        this.redirect('/login');
        displayInfo('Logout successful.');
      })
      .catch(err => displayError(err.message));
  });
  //-------------------- CREATE --------------------
  this.get('/create', function(context) {
    const auth = localStorage.getItem('auth');
    if (auth) {
      const { uid, email } = JSON.parse(auth);
      context.isLoggedIn = true;
      context.email = email;
    }

    this.loadPartials({
      'nav': '../templates/common/nav.hbs',
      'footer': '../templates/common/footer.hbs',
    })
    .then(function () {
      this.partial('../templates/destinations/create.hbs');
    });
  });

  this.post('/create', function(context) {
    const { destination, city, duration, departureDate, imgUrl } = context.params;
    if (destination === '' || city === '' || duration === '' || departureDate === '' || imgUrl === '') {
      displayError('Please fill correct data.');
    } else {
      firebase.firestore().collection('destinations').add({
        destination, city, duration, departureDate, imgUrl,
        creator: JSON.parse(localStorage.getItem('auth')).email
      })
      .then(this.redirect('/home'))
      .then(displayInfo('Destination created successfully.'))
      .catch(err => displayError(err.message));
    }
  });

  //-------------------- DETAILS -------------------
  this.get('/details/:id', async function(context) {
    const auth = localStorage.getItem('auth');
    if (auth) {
      const { uid, email } = JSON.parse(auth);
      context.isLoggedIn = true;
      context.email = email;
      context.id = context.params.id;

      await firebase.firestore().collection('destinations').doc(context.params.id).get().then(res => {
        context.destinationData = res.data();
        context.isCreator = email === context.destinationData.creator;

        let depDate = res.data().departureDate.split('-');
        const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        context.departureDate = `${depDate[2]} ${months[+depDate[1] - 1]} ${depDate[0]}`;
      });
    }

    this.loadPartials({
      'nav': '../templates/common/nav.hbs',
      'footer': '../templates/common/footer.hbs',
    })
    .then(function () {
      this.partial('../templates/destinations/details.hbs');
    });
  });

  //-------------------- EDIT ----------------------
  this.get('/edit/:id', async function(context) {
    const auth = localStorage.getItem('auth');
    if (auth) {
      const { uid, email } = JSON.parse(auth);
      context.isLoggedIn = true;
      context.email = email;
      context.id = context.params.id;

      await firebase.firestore().collection('destinations').doc(context.params.id).get().then(res => {
        context.destinationData = res.data();
      });
    }

    this.loadPartials({
      'nav': '../templates/common/nav.hbs',
      'footer': '../templates/common/footer.hbs',
    })
    .then(function() {
      this.partial('../templates/destinations/edit.hbs');
    });
  });

  this.post('/edit/:id', function(context) {
    const { id, destination, city, duration, departureDate, imgUrl } = context.params;
    if (destination === '' || city === '' || duration === '' || departureDate === '' || imgUrl === '') {
      displayError('Please fill correct data.');
    } else {
      firebase.firestore().collection('destinations').doc(context.params.id).set({
        destination, city, duration, departureDate, imgUrl
      }, { merge: true })
      .then(this.redirect(`/details/${id}`))
      .then(displayInfo('Successfully edited destination.'))
      .catch(err => displayError(err.message));
    }
  });

  //---------------- MY DESTINATIONS ---------------
  this.get('/destinations', async function(context) {
    const auth = localStorage.getItem('auth');
    if (auth) {
      context.destinations = [];
      await firebase.firestore().collection("destinations").get().then(res => {
        const auth = localStorage.getItem('auth');
        const { uid, email } = JSON.parse(auth);
        context.isLoggedIn = true;
        context.email = email;

        res.forEach(doc => {
          let obj = { id: doc.id, ...doc.data() };
          if (obj.creator === email) {
            context.destinations.push(obj);
          }
        });
      });
    }

    this.loadPartials({
      'nav': '../templates/common/nav.hbs',
      'footer': '../templates/common/footer.hbs',
      'destinationTicket': '../templates/destinations/destinationTicket.hbs',
    })
    .then(function() {
      this.partial('../templates/destinations/destinations.hbs');
    });
  });

  //-------------------- DELETE --------------------
  this.get('/delete/:id', function(context) {
    firebase.firestore().collection('destinations').doc(context.params.id).delete()
      .then(this.redirect('/destinations'))
      .then(displayInfo('Destination deleted.'))
      .catch(err => displayError(err.message));
  });

  //------------------------------------------------
});

(() => {  // Initial template load (first, when page loads)
  app.run('/home');
})();

function displayError(message) {
  let errorBox = document.querySelector('.notification.errorBox');
  errorBox.textContent = message;
  errorBox.style.display = 'block';
  setTimeout(() => { errorBox.textContent = ''; errorBox.style.display = 'none'; }, 1500);
}

function displayInfo(message) {
  let infoBox = document.querySelector('.notification.infoBox');
  infoBox.textContent = message;
  infoBox.style.display = 'block';
  setTimeout(() => { infoBox.textContent = ''; infoBox.style.display = 'none'; }, 1500);
}