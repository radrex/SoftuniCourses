Promise.all([
  fetch('./template.hbs').then(x => x.text()),
  fetch('./cat.hbs').then(x => x.text()),
])
.then(([templateRaw, partialTemplateRaw]) => {
  Handlebars.registerPartial('cat', partialTemplateRaw);
  let template = Handlebars.compile(templateRaw);
  document.getElementById('allCats').innerHTML = template({ cats });
  document.addEventListener('click', function (evt) {
    if (evt.target && evt.target.nodeName === 'BUTTON') {
      if (evt.target.nextElementSibling.style.display === 'none') {
        evt.target.nextElementSibling.style.display = 'block';
        evt.target.textContent = 'Hide status code'
      } else {
        evt.target.nextElementSibling.style.display = 'none';
        evt.target.textContent = 'Show status code';
      }
    }
  })
  .catch(err => console.log(err));
});
