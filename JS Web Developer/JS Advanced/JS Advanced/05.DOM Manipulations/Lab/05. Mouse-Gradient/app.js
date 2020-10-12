function attachGradientEvents() {
  let gradient = document.getElementById('gradient');
  let result = document.getElementById('result');

  gradient.addEventListener('mousemove', mouseMove);
  gradient.addEventListener('mouseout', mouseOut);

  function mouseMove(evt) {
    let percentage = Math.floor((evt.offsetX / gradient.clientWidth) * 100);
    result.textContent = `${percentage}%`;
  }

  function mouseOut() {
    result.textContent = '';
  }
}