function stopwatch() {
  let timeElement = document.getElementById('time');
  let startBtnElement = document.getElementById('startBtn');
  let stopBtnElement = document.getElementById('stopBtn');

  if (timeElement === null || startBtnElement === null || stopBtnElement === null) {
    throw new Error('Something went wrong...');
  }

  let min = 0;
  let sec = 0;
  let interval = null;

  startBtnElement.addEventListener('click', function() {
    sec = '00';
    min = '00';
    timeElement.textContent = `${min}:${sec}`;
    interval = setInterval(add, 1000);
    startBtnElement.setAttribute('disabled', true);
    stopBtnElement.removeAttribute('disabled');
  });

  stopBtnElement.addEventListener('click', function() {
    stopBtnElement.setAttribute('disabled', true);
    startBtnElement.removeAttribute('disabled');
    clearInterval(interval);
  })

  function add() {
    sec++;
    if (sec < 10) {
      sec = `0${sec}`;
    }

    if (sec >= 60) {
      sec = '00';
      min++;

      if (min < 10) {
        min = `0${min}`;
      }
    }

    if (min === 0) {
      min = `0${min}`;
    }
    
    timeElement.textContent = `${min}:${sec}`;
  }
}
