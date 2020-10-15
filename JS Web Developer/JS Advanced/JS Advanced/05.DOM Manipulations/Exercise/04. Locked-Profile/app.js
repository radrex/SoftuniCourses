//---- WITH EVENT DELEGATION (attaching only 1 event listener and using 'target' to capture elements, without attaching event listener to each one of them) ----
function lockedProfile() {
  let mainElement = document.getElementById('main');

  if (mainElement === null) {
    throw new Error('Something went wrong...');
  }

  mainElement.addEventListener('click', function(evt) {
    if (evt.target && evt.target.nodeName === 'BUTTON') {
      let lockStatus = evt.target.parentNode.querySelector('input[type="radio"]:checked').value;
      
      if (lockStatus === 'unlock') {
        switch (evt.target.textContent) {
          case 'Show more':
            evt.target.previousElementSibling.style.display = 'inline-block';
            evt.target.textContent = 'Hide it';
            break;

          case 'Hide it':
            evt.target.previousElementSibling.style.display = 'none';
            evt.target.textContent = 'Show more';
            break;
        
          default:
            break;
        }
      }
    }
  });
}
