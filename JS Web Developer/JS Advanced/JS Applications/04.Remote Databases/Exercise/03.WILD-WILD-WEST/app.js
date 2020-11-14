import { fetchPlayers, addPlayer, deletePlayer, playGame } from "./data.js";

let baseUrl = 'https://remotedb-55dd4.firebaseio.com/';
const actions = {
  'Add Player': () => addPlayer(),
  'Delete': (element) => deletePlayer(element),
  'Play': (element) => playGame(element),
};

fetchPlayers();

document.addEventListener('click', function (evt) {
  evt.preventDefault();
  if (evt.target && evt.target.nodeName === "BUTTON") {
    actions[evt.target.textContent](evt.target);
  }
});

