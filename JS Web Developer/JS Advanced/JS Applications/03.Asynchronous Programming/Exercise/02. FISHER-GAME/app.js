function attachEvents() {
  let body = document.getElementsByTagName('body')[0];
  let baseUrl = 'https://fisher-game.firebaseio.com/catches/';

  const actions = {
    'Add': () => {
      let name = document.querySelector('aside > fieldset > .angler');
      let weight = document.querySelector('aside > fieldset > .weight');
      let species = document.querySelector('aside > fieldset > .species');
      let location = document.querySelector('aside > fieldset > .location');
      let bait = document.querySelector('aside > fieldset > .bait');
      let captureTime = document.querySelector('aside > fieldset > .captureTime');

      if (name.value !== '' && weight.value !== '' && species.value !== '' && location.value !== '' && bait.value !== '' && captureTime.value !== '') {
        fetch(`${baseUrl}.json`, {
          method: 'POST',
          headers: { 'Content-type': 'application/json' },
          body: JSON.stringify({ "angler": name.value, "weight": weight.value, "species": species.value, "location": location.value, "bait": bait.value, "captureTime": captureTime.value }),
        })
      }

      name.value = '';
      weight.value = '';
      species.value = '';
      location.value = '';
      bait.value = '';
      captureTime.value = '';
    },
    'Load': () => {
      let catches = document.getElementById('catches');
      fetch(`${baseUrl}.json`)
        .then(x => x.json())
        .then(allCatches => {
          catches.innerHTML = Object.entries(allCatches).map(([key, value]) => 
            `<div class="catch" data-id="${key}">` +
              `<label>Angler</label>` + `<input type="text" class="angler" value="${value.angler}" />` + `<hr>` + 
              `<label>Weight</label>` + `<input type="number" class="weight" value="${value.weight}" />` + `<hr>` + 
              `<label>Species</label>` + `<input type="text" class="species" value="${value.species}" />` + `<hr>` + 
              `<label>Location</label>` + `<input type="text" class="location" value="${value.location}" />` + `<hr>` + 
              `<label>Bait</label>` + `<input type="text" class="bait" value="${value.bait}" />` + `<hr>` + 
              `<label>Capture Time</label>` + `<input type="number" class="captureTime" value="${value.captureTime}" />` + `<hr>` + 
              `<button class="update">Update</button>` + `<button class="delete">Delete</button>` +
            `</div>`
            ).join('');
        }).catch(console.error());
    },
    'Update': (element) => {
      let name = element.querySelector('.angler');
      let weight = element.querySelector('.weight');
      let species = element.querySelector('.species');
      let location = element.querySelector('.location');
      let bait = element.querySelector('.bait');
      let captureTime = element.querySelector('.captureTime');

      let catchId = element.getAttribute('data-id');
      fetch(`${baseUrl}${catchId}.json`, {
        method: 'PUT',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify({ "angler": name.value, "weight": weight.value, "species": species.value, "location": location.value, "bait": bait.value, "captureTime": captureTime.value }),
      })
      .catch(console.error());
    },
    'Delete': (element) => {
      let catchId = element.getAttribute('data-id');
      fetch(`${baseUrl}${catchId}.json`, {
        method: 'DELETE',
      })
      .catch(console.error());
      element.remove();
    },
  };

  body.addEventListener('click', function(evt) {
    if (evt.target && evt.target.nodeName === 'BUTTON') {
      actions[evt.target.textContent](evt.target.parentElement);
    }
  });
}

attachEvents();

