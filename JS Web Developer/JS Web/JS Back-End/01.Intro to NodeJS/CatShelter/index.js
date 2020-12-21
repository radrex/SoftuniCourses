//------ NodeJS Core Modules ------
const http = require('http');
const path = require('path');
const fs = require('fs');
const qs = require('querystring');

//------ Third-Partu Modules ------
const formidable = require('formidable');

//----------- CONSTANTS -----------
const VIEWS_PATH = path.resolve('views');
const DATA_PATH = path.resolve('data');
const DATA_BREEDS_PATH = path.join(DATA_PATH, '/breeds.json');
const DATA_CATS_PATH = path.join(DATA_PATH, '/cats.json');
const CONTENT_PATH = path.resolve('content');

const fileRoutes = {
  '/': '/home/index.html',
  '/cats/add-breed': '/addBreed.html',
  '/cats/add-cat': '/addCat.html',
};

const mimeTypes = {
  '.html': 'text/html',
  '.css': 'text/css',
  '.js': 'application/javascript',
  '.json': 'application/json',
};

//-----------------------------------------------------------------------------------
http.createServer(httpHandler).listen(3000, function() {
  console.log(`Server is listening on port 3000...`);
});

function httpHandler(request, response) {
  const { pathname, searchParams } = new URL(request.url, `http://${request.headers.host}`);
  const method = request.method.toUpperCase();
  actions[method](request, response, pathname);
}

//----------- ACTION OBJS -----------
const actions = {
  GET: (request, response, pathname) => {
    if (pathname.includes('/content/')) { // For static files
      const fullStaticFilePath = path.resolve(pathname.slice(1));
      sendFile(response, fullStaticFilePath, pathname);
      return;
    }

    const relativeFilePath = fileRoutes[pathname];
    if (!relativeFilePath) {
      const body = 'Not Found';
      response.writeHead(404, {
        'Content-Length': Buffer.byteLength(body),
        'Content-Type': 'text/plain'
      }).end(body);
      return;
    }

    const fullFilePath = path.join(VIEWS_PATH, relativeFilePath);
    sendFile(response, fullFilePath, pathname);
  },
  POST: (request, response, pathname) => {
    if (pathname === '/cats/add-breed') {
      collectRequestData(request, result => {
        fs.readFile(DATA_BREEDS_PATH, function(err, data) {
          let json;
          if (data.length !== 0) { // .json file is not empty
            json = JSON.parse(data);
            json.push(result.breed);
          } else {  // .json file is empty
            json = [result.breed];
          }
  
          fs.writeFile(DATA_BREEDS_PATH, JSON.stringify(json), (err) => {
            if (err) {
              console.log(err);
              return;
            }
          });
        });
        response.writeHead(301, { location: '/' }).end();
      });
    } else if (pathname === '/cats/add-cat') {
      collectRequestData(request, result => {
        fs.readFile(DATA_CATS_PATH, function(err, data) {
          let json;
          if (data.length !== 0) {
            json = JSON.parse(data);
            json.push({breed: result.breed, description: result.description, name: result.name, path: result.newPath, imageRelativePath: result.imageRelativePath });
          } else {
            json = [{breed: result.breed, description: result.description, name: result.name, path:result.newPath, imageRelativePath: result.imageRelativePath }];
          }

          //TODO: Check if file with the same name already exists in images, otherwise the code below will replace the old one.
          fs.copyFile(result.oldPath, result.newPath, function(err) {
            if (err) {
              console.log(err);
            }
          });//TODO: Remove file from TEMP

          fs.writeFile(DATA_CATS_PATH, JSON.stringify(json), (err) => {
            console.log(err);
            return;
          });
        });
        response.writeHead(301, { location: '/' }).end();
      });
    }
  }
};

function sendFile(response, fullFilePath, pathname) {
  const fileExt = path.extname(fullFilePath);
  const mimeType = mimeTypes[fileExt];

  fs.readFile(fullFilePath, function(err, data) {
    if (err) {
      const { message } = err;
      response.writeHead(500, {
        'Content-Length': Buffer.byteLength(message),
        'Content-Type': 'text/plain'
      })
      .end(message);
      return;
    }

    if (pathname === '/cats/add-cat') {
      fs.readFile(DATA_BREEDS_PATH, function(err, buffer) {
        let breeds;
        if (buffer.length !== 0) {
          breeds = JSON.parse(buffer);
        } else {
          breeds = [];
        }

        let catBreedPlaceholder = breeds.map(breed => `<option value="${breed}">${breed}</option>`).join('');
        data = data.toString().replace('{{catBreeds}}', catBreedPlaceholder);
        response.writeHead(200, {
          'Content-Length': Buffer.byteLength(data),
          'Content-Type': mimeType || 'text/plain'
        }).end(data);
      });
    } else if (pathname === '/') {
      fs.readFile(DATA_CATS_PATH, function(err, buffer) {
        let cats;
        if (buffer.length !== 0) {
          cats = JSON.parse(buffer);
        } else {
          cats = [];
        }

        let catsPlaceholder = cats.map(cat => `
          <li>
            <img src="${cat.imageRelativePath}" alt="${cat.name}">
            <h3>${cat.name}</h3>
            <p><span>Breed: </span>${cat.breed}</p>
            <p><span>Description: </span>${cat.description}</p>
            <ul class="buttons">
              <li class="btn edit"><a href="">Change Info</a></li>
              <li class="btn delete"><a href="">New Home</a></li>
            </ul>
          </li>
        `).join('');

        data = data.toString().replace('{{cats}}', catsPlaceholder);
        response.writeHead(200, {
          'Content-Length': Buffer.byteLength(data),
          'Content-Type': mimeType || 'text/plain'
        }).end(data);
      });
    } else {
      response.writeHead(200, {
        'Content-Length': Buffer.byteLength(data),
        'Content-Type': mimeType || 'text/plain'
      }).end(data);
    }
  });
}

function collectRequestData(request, callback) {
  const FORM_URLENCODED = 'application/x-www-form-urlencoded';
  const FORM_MULTIPART = 'multipart/form-data';

  if (request.headers['content-type'] === FORM_URLENCODED) {
    let body = '';
    request.on('data', chunk => {
      body += chunk.toString(); // convert Buffer to string
    });
    request.on('end', () => {
      callback(qs.parse(body));
    });
  } else if (request.headers['content-type'].includes(FORM_MULTIPART)) {
    let data = {};
    const form = formidable({ multiples: true });
    form.parse(request, (err, fields, files) => {
      data.oldPath = files.upload.path;
      data.newPath = `${CONTENT_PATH}/images/${files.upload.name}`;
      data.imageRelativePath = `/content/images/${files.upload.name}`;
      data.breed = fields.breed;
      data.description = fields.description;
      data.name = fields.name;
    });

    request.on('end', () => {
      callback(data);
    });
  } else {
    callback(null);
  }
}

