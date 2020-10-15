//---- WITH EVENT DELEGATION (attaching only 1 event listener and using 'target' to capture elements, without attaching event listener to each one of them) ----
function attachEventsListeners() {
  let mainElement = document.getElementsByTagName('main')[0];

  let days = document.getElementById('days');
  let hours = document.getElementById('hours');
  let minutes = document.getElementById('minutes');
  let seconds = document.getElementById('seconds');

  if (mainElement === null || days === null || hours === null || minutes === null || seconds === null) {
    throw new Error('Something went wrong...');
  }

  mainElement.addEventListener('click', function(evt) {
    if (evt.target && evt.target.nodeName === 'INPUT' && evt.target.type === 'button') {
      convert(Number(evt.target.previousElementSibling.value), evt.target.id);
    }
  }, true);

  function convert(value, id) {
    switch (id) {
      case 'daysBtn':
        hours.value = value * 24;
        minutes.value = value * 1440;
        seconds.value = value * 86400; 
        break;

      case 'hoursBtn':
        days.value = value / 24;
        minutes.value = value * 60;
        seconds.value = value * 3600;
        break;

      case 'minutesBtn':
        days.value = value / 1440;
        hours.value = value / 60;
        seconds.value = value * 60;
        break;

      case 'secondsBtn':
        days.value = value / 86400;
        hours.value = value / 3600;
        minutes.value = value / 60;
        break;
  
      default:
        break;
    }
  }
}