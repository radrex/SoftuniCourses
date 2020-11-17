import monkeys from "./monkeys.js";

fetch('./template.hbs')
  .then(x => x.text())
  .then(templateRaw => {
    let template = Handlebars.compile(templateRaw);
    document.querySelector('.monkeys').innerHTML = template({ monkeys });
    document.addEventListener('click', function(evt) {
      if (evt.target && evt.target.nodeName === 'BUTTON') {
        if (evt.target.nextElementSibling.style.display === 'none') {
          evt.target.nextElementSibling.style.display = 'block';
          evt.target.textContent = 'Hide Info';
        } else {
          evt.target.nextElementSibling.style.display = 'none';
          evt.target.textContent = 'Info';
        }
      }
    });
  })
  .catch(err => console.log(err));