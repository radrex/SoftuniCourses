function attachEvents() {
  let locationInput = document.getElementById('location');
  let submitBtn = document.getElementById('submit');
  let forecast = document.getElementById('forecast');

  if (locationInput == null || submitBtn == null || forecast == null) {
    throw new Error('Something went wrong...');
  }

  let baseUrl = 'https://judgetests.firebaseio.com';
  submitBtn.addEventListener('click', function() {
    fetch(`${baseUrl}/locations.json`)
      .then(x => x.json())
      .then(locations => {
        let loc = locations.find(x => x.name === locationInput.value);
        if (loc == undefined) {
          throw new Error(`Error`);
        }

        let today = fetch(`${baseUrl}/forecast/today/${loc.code}.json`).then(x => x.json());
        let upcoming = fetch(`${baseUrl}/forecast/upcoming/${loc.code}.json`).then(x => x.json());

        const conditions = {
          'Sunny': '&#x2600;',
          'Partly sunny': '&#x26C5;',
          'Overcast': '&#x2601;',
          'Rain': '&#x2614;',
        };

        Promise.all([today, upcoming])
          .then(([todayData, upcomingData]) => {
             [...forecast.getElementsByTagName('p')].forEach(x => x.remove());
             forecast.style.display = 'block';
             forecast.firstElementChild.style.display = 'block';
             forecast.lastElementChild.style.display = 'block';

             let todayDiv = document.createElement('div');
             todayDiv.classList.add('forecasts');
             todayDiv.innerHTML = 
             `<span class="condition symbol">${conditions[todayData.forecast.condition]}</span>` +
               `<span class="condition">` +
               `<span class="forecast-data">${todayData.name}</span>`+
               `<span class="forecast-data">${todayData.forecast.low}&#176;/${todayData.forecast.high}&#176;</span>`+
               `<span class="forecast-data">${todayData.forecast.condition}</span>` +
             `</span>`;
             forecast.firstElementChild.appendChild(todayDiv);

             let upcomingDiv = document.createElement('div');
             upcomingDiv.classList.add('forecast-info');
             upcomingDiv.innerHTML = upcomingData.forecast.map(x => 
                `<span class="upcoming">` +
                `<span class="symbol">${conditions[x.condition]}</span>` +
                `<span class="forecast-data">${x.low}&#176;/${x.high}&#176;</span>` +
                `<span class="forecast-data">${x.condition}</span>` +
                `</span>`
             ).join('');

             forecast.lastElementChild.appendChild(upcomingDiv);
          })
      })
      .catch(err => {
        forecast.style.display = 'block';
        forecast.firstElementChild.style.display = 'none';
        forecast.lastElementChild.style.display = 'none';

        let p = document.createElement('p');
        p.textContent = err.message;
        forecast.appendChild(p);
      });
  });
}

attachEvents();