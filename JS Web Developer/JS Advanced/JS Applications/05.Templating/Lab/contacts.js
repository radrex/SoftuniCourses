const contacts = [
    {
        id: 1,
        name: "John",
        phoneNumber: "0847759632",
        email: "john@john.com"
    },
    {
        id: 2,
        name: "Merrie",
        phoneNumber: "0845996111",
        email: "merrie@merrie.com"
    },
    {
        id: 3,
        name: "Adam",
        phoneNumber: "0866592475",
        email: "adam@stamat.com"
    },
    {
        id: 4,
        name: "Peter",
        phoneNumber: "0866592475",
        email: "peter@peter.com"
    },
    {
        id: 5,
        name: "Max",
        phoneNumber: "0866592475",
        email: "max@max.com"
    },
    {
        id: 6,
        name: "David",
        phoneNumber: "0866592475",
        email: "david@david.com"
    }
];

let templateRaw = document.getElementById("contacts-template").innerHTML;
let template = Handlebars.compile(templateRaw);
document.getElementById('contacts').innerHTML = template({contacts});

document.addEventListener('click', function(evt) {
  if (evt.target && evt.target.nodeName === "BUTTON") {
    if (evt.target.nextElementSibling.style.display === 'none') {
      evt.target.nextElementSibling.style.display = 'block';
      evt.target.textContent = 'Hide Details'
    } else {
      evt.target.nextElementSibling.style.display = 'none';
      evt.target.textContent = 'Details'
    }
  }
});
