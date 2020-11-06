function getInfo() {
  let input = document.getElementById('stopId');
  let busStop = document.getElementById('stopName');
  let buses = document.getElementById('buses');

  if (input == null || busStop == null || buses == null) {
    throw new Error('Something went wrong...');
  }

  let uri = `https://judgetests.firebaseio.com/businfo/${input.value}.json`;

  fetch(uri)
    .then(x => x.json())
    .then(x => {
      busStop.textContent = x.name;
      buses.innerHTML = Object.entries(x.buses).map(([bus, minutes]) => `<li>Bus ${bus} arrives in ${minutes} minutes</li>`).join('');
    })
    .catch(() => {
      buses.innerHTML = '';
      busStop.textContent = 'Error';
    });
}