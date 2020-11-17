document.addEventListener('click', function (evt) {
  evt.preventDefault();
  if (evt.target && evt.target.nodeName === 'BUTTON') {
    let towns = document.getElementById('towns').value;
    if (towns !== '') {
      towns = towns.split(/[, ]+/g).map(x => { return { name: x } });
    }

    fetch('./template.hbs')
      .then(x => x.text())
      .then(templateRaw => {
        let template = Handlebars.compile(templateRaw);
        document.getElementById('root').innerHTML = template({ towns });
      })
      .catch(err => console.log(err));
  }
});