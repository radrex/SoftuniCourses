const router = Sammy('#main', function() {
  this.use('Handlebars', 'hbs'); // Specify Template Engine and its extension so it can compile

  //--------------------- HOME ---------------------
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

  //--------------------- ABOUT --------------------
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

  //--------------------- LOGIN --------------------
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
  this.post('/login', function(context) {
    const { email, password } = context.params;

    firebase.auth().signInWithEmailAndPassword(email, password)
      .then(user => {
        const { user: { uid, email } } = user;
        localStorage.setItem('userInfo', JSON.stringify({ uid, email }));
        this.redirect('/home');
      })
      .then(displayInfo('Logged in successfully.'))
      .catch(err => console.log(err));
  });
  
  //------------------- REGISTER -------------------
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
  this.post('/register', function(context) {
    // these properties come from context.params, which come from input's 'name' attribute
    const { email, password, repeatPassword } = context.params;
    let emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!emailRegex.test(email) || password === '' || password !== repeatPassword) {
      displayError('Invalid email or password.');
    } else {
      firebase.auth().createUserWithEmailAndPassword(email, password)
      .then(this.redirect('/login'))
      .then(displayInfo('Registered successfully.'))
      .catch(err => console.log(err));
    }
  });
  
  //-------------------- LOGOUT --------------------
  this.get('/logout', function() {
    firebase.auth().signOut().then(() => {
        localStorage.removeItem('userInfo');
        this.redirect('/home');
      })
      .then(displayInfo('Logged out successfully.'))
      .catch(err => console.log(err));
  });

  //-------------------- CATALOG -------------------
  this.get('/catalog', async function(context) {
    const userInfo = localStorage.getItem('userInfo'); 
    if (userInfo) {
      const { uid, email } = JSON.parse(userInfo);
      context.loggedIn = true;
      context.email = email;
      context.teams = [];

      await firebase.firestore().collection('teams').get().then(res => {
        res.forEach(doc => context.teams.push({id: doc.id, ...doc.data()}));
        if (context.teams.some(x => x.members.some(x => x.email === email))) {
          context.hasNoTeam = false;
        } else {
          context.hasNoTeam = true;
        }
      });
    }

    this.loadPartials({
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
      'team': '../templates/catalog/team.hbs',
    })
    .then(function() {
      this.partial('../templates/catalog/teamCatalog.hbs');
    });
  });

  //-------------------- CREATE -------------------
  this.get('/create', function(context) {
    const userInfo = localStorage.getItem('userInfo'); 
    if (userInfo) {
      const { uid, email } = JSON.parse(userInfo);
      context.loggedIn = true;
      context.email = email;
    
      this.loadPartials({
        'header': '../templates/common/header.hbs',
        'footer': '../templates/common/footer.hbs',
        'createForm': '../templates/create/createForm.hbs',
      })
      .then(function() {
        this.partial('../templates/create/createPage.hbs');
      });
    }
  });
  this.post('/create', function(context) {
    const { name, comment } = context.params;

    if (name === '' || comment === '') {
      displayError('Fields must not be empty.')
    } else {
      let creator = JSON.parse(localStorage.getItem('userInfo'));
      creator.isAuthor = true;
      creator.isOnTeam = true;

      firebase.firestore().collection('teams').add({
        name, comment,
        members: [creator],
      })
      .then(this.redirect('/catalog'))
      .then(displayInfo('Team created sucessfully.'))
      .catch(err => console.log(err));;
    }
  });

  //-------------------- DETAILS ------------------
  this.get('/details/:id', async function(context) {
    const userInfo = localStorage.getItem('userInfo'); 
    if (userInfo) {
      const { uid, email } = JSON.parse(userInfo);
      context.loggedIn = true;
      context.email = email;
      context.id = context.params.id;

      await firebase.firestore().collection('teams').doc(context.id).get().then(res => {
        context.teamData = res.data();
        context.member = context.teamData.members.find(x => x.email === email);
        context.teamData.members = context.teamData.members.filter(x => x.isOnTeam === true);
      });
    }

    this.loadPartials({
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
      'teamMember': '../templates/catalog/teamMember.hbs',
      'teamControls': '../templates/catalog/teamControls.hbs',
    })
    .then(function() {
      this.partial('../templates/catalog/details.hbs');
    });
  });

  //--------------------- EDIT --------------------
  this.get('/edit/:id', async function(context) {
    const userInfo = localStorage.getItem('userInfo'); 
    if (userInfo) {
      const { uid, email } = JSON.parse(userInfo);
      context.loggedIn = true;
      context.email = email;
      context.id = context.params.id;

      await firebase.firestore().collection('teams').doc(context.id).get().then(res => {
        context.teamData = res.data();
      });
    }

    this.loadPartials({
      'header': '../templates/common/header.hbs',
      'footer': '../templates/common/footer.hbs',
      'editForm': '../templates/edit/editForm.hbs',
    })
    .then(function() {
      this.partial('../templates/edit/editPage.hbs');
    });
  });
  this.post('/edit/:id', function(context) {
    const { id, name, comment } = context.params;
    if (name === '' || comment === '') {
      displayError('Fields must not be empty.')
    } else {
      firebase.firestore().collection('teams').doc(context.params.id).set({
        name, comment
      }, { merge: true })
      .then(this.redirect(`/details/${id}`))
      .then(displayInfo('Team edited successfully.'))
      .catch(err => console.log(err));
    }
  });

  //-------------------- LEAVE --------------------
  this.get('/leave/:id', async function(context) {
    const userInfo = localStorage.getItem('userInfo'); 
    if (userInfo) {
      const { uid, email } = JSON.parse(userInfo);

      await firebase.firestore().collection('teams').doc(context.params.id).get().then(res => {
        let data = res.data();
        data.members.map(x => {
          if (x.email === email) {
            x.isOnTeam = false;
          }
          return;
        })

        return data;
      })
      .then(data => {
        firebase.firestore().collection('teams').doc(context.params.id).set(data);
      })
      .then(this.redirect('/catalog'))
      .then(displayInfo('You left the team.'))
      .catch(err => console.log(err));
    }
  });

  //-------------------- JOIN ---------------------
  this.get('/join/:id', async function(context) {
    const userInfo = localStorage.getItem('userInfo'); 
    if (userInfo) {
      const { uid, email } = JSON.parse(userInfo);
      context.loggedIn = true;
      context.email = email;
      context.id = context.params.id;

      await firebase.firestore().collection('teams').doc(context.id).get().then(res => {
        let data = res.data();

        let member = data.members.find(x => x.email === email);
        if (member) {
          member.isOnTeam = true;
        } else {
          data.members.push({email, uid, isAuthor:false, isOnTeam:true });
        }

        return data;
      })
      .then(data => {
        firebase.firestore().collection('teams').doc(context.id).set(data);
      })
      .then(this.redirect(`/catalog`))
      .then(displayInfo('You joined the selected team.'))
      .catch(err => console.log(err));
    }
  });
});

(() => {  // Initial template load (first, when page loads)
  router.run('/home');
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