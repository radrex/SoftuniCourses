const baseURL = 'https://workshopspa-630ba.firebaseio.com';

const apiEndpoints = {
  movies: `${baseURL}/Movies.json`,
  //TODO: add movie: url with id placeholder
}

async function addMovie(title, description, imageUrl, creator) {
  return await fetch(apiEndpoints.movies, {
    method: 'POST',
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify({ title, description, imageUrl, creator, likes: 0 }),
  })
  .catch(err => console.log(err));
}

async function getMovies() {
  let res = await fetch(apiEndpoints.movies).then(x => x.json());
  return Object.keys(res).map(id => ({ id, ...res[id] }));
}

async function getMovie(id) {
  return await fetch(`${baseURL}/Movies/${id}.json`).then(x => x.json());
}

function deleteMovie(id) {
  fetch(`${baseURL}/Movies/${id}.json`, { method: 'DELETE' });
}

function likeMovie(id) {
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

async function editMovie(id, title, description, imageUrl) {
  await fetch(`${baseURL}/Movies/${id}.json`, {
    method: 'PATCH',
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify({ title, description, imageUrl }),
  });
}

export { addMovie, getMovies, getMovie, deleteMovie, likeMovie, deleteMovie, editMovie };
