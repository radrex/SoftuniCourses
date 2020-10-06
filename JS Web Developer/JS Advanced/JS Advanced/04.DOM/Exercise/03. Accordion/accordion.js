function toggle() {
  let buttonElement = document.getElementsByClassName('button')[0];
  let divElement = document.getElementById('extra');

  if (buttonElement === null || divElement === null) {
    throw new Error('Something went wrong...');
  }

  const actions = {
    'More': 'Less',
    'Less': 'More',
    '': 'block',
    'none': 'block',
    'block': 'none',
  };

  buttonElement.innerHTML = actions[buttonElement.innerHTML];
  divElement.style.display = actions[divElement.style.display];
}

/* ---- NOT WORKING IN JUDGE DUE TO USAGE OF "getComputedStyle"
  function toggle() {
    let buttonElement = document.getElementsByClassName('button')[0];
    let divElement = document.getElementById('extra');

    if (buttonElement === null || divElement === null) {
      throw new Error('Something went wrong...');
    }

    const actions = {
      'More': 'Less',
      'Less': 'More',
      'none': 'block',
      'block': 'none',
    };

    buttonElement.innerHTML = actions[buttonElement.innerHTML];
    divElement.style.display = actions[getComputedStyle(divElement).display];
  }
*/
