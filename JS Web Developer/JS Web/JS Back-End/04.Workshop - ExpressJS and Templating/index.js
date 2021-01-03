global.__basedir = __dirname;

const env = process.env.NODE_ENV || 'development';

const config = require('./config/config')[env];
const app = require('express')();

require('./config/express')(app);
require('./config/routes')(app);

app.use(function(err, req, res, next) {
  // capture thrown errors here
});

app.listen(config.port, console.log(`Listening on port ${config.port}! Now its up to you...`));