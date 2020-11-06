function solve() {
  let infoBox = document.querySelector('#info .info');
  let uri = `https://judgetests.firebaseio.com/schedule/depot.json`;

  function depart() {
    let depart = document.getElementById('depart');
    let arrive = document.getElementById('arrive');

    fetch(uri)
      .then(x => x.json())
      .then(x => {
        infoBox.textContent = `Next stop ${x.name}`;
        depart.disabled = true;
        arrive.disabled = false;
      })
      .catch(() => {
        infoBox.textContent = 'Error';
        depart.disabled = true;
        arrive.disabled = true;
      });
  }

  function arrive() {
    let depart = document.getElementById('depart');
    let arrive = document.getElementById('arrive');

    fetch(uri)
      .then(x => x.json())
      .then(x => {
        infoBox.textContent = `Arriving at ${x.name}`;
        uri = `https://judgetests.firebaseio.com/schedule/${x.next}.json`;
        depart.disabled = false;
        arrive.disabled = true;
      })
      .catch(() => {
        infoBox.textContent = 'Error';
        depart.disabled = true;
        arrive.disabled = true;
      });
  }

  return {
    depart,
    arrive
  };
}

let result = solve();