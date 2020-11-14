import { html, constructDiv } from "./dom.js";
import { loadCanvas } from "./loadCanvas.js";

const baseUrl = 'https://remotedb-55dd4.firebaseio.com/';

//----------- ERROR HANDLING and DATA PARSE -----------
function handleError(response) {
  if (!response.ok) {
    throw new Error(response.statusText);
  }
  return response;
}

function deserializeData(response) { return response.json(); }

//--------------------- DATA CRUD ---------------------
function fetchPlayers() {
  fetch(`${baseUrl}Players.json`)
  .then(handleError)
  .then(deserializeData)
  .then(constructDiv)
  .catch(err => console.log(err));
}

function addPlayer() {
  let name = html.player();

  if (name.value !== '') {
    fetch(`${baseUrl}Players.json`, {
      method: 'POST',
      headers: { 'Content-type': 'application/json' },
      body: JSON.stringify({ "name": name.value, "money": 500, "bullets": 6 }),
    })
    .then(fetchPlayers)
    .catch(err => console.log(err));
  }
}

function deletePlayer(element) {
  fetch(`${baseUrl}Players/${element.getAttribute('data-key')}.json`, { method: 'DELETE' })
    .then(err => console.log(err));
  element.parentElement.remove();
}

function playGame(element) {
  //TODO load canvas
  debugger;
  loadCanvas();
}

export { fetchPlayers, addPlayer, deletePlayer, playGame };