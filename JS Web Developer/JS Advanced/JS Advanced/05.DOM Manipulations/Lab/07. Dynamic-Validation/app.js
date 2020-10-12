function validate() {
  let inputElement = document.getElementById('email');

  if (inputElement === null) {
    throw new Error('Something went wrong...');
  }

  let regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  inputElement.addEventListener('change', function(evt) {
    if (regex.test(evt.target.value)) {
      evt.target.removeAttribute('class');
      return;
    }

    evt.target.className = 'error';
  });
}
