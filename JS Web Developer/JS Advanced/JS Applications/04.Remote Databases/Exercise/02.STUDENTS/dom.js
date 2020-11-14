const html = {
  tbody: () => document.getElementById('tbody'),
  studentFirstName: () => document.getElementById('fname'),
  studentLastName: () => document.getElementById('lname'),
  facultyNumber: () => document.getElementById('fnumber'),
  grade: () => document.getElementById('grade'),
  submit: () => document.getElementById('submit'),
};

function createDOMElement(tag, attributes, content, ...children) {
  const element = document.createElement(tag);
  Object.entries(attributes).forEach(([key, value]) => element.setAttribute(key, value));
  if (content !== '') {
    element.textContent = content;
  }
  
  element.append(...children);
  return element;
}

function constructTable(json) {
  if (json != null) {
    let fragment = new DocumentFragment();
    Object.entries(json).forEach(([key, {id, firstName, lastName, facultyNumber, grade}]) => {
      let tr = createDOMElement('tr', {}, '', 
                  createDOMElement('td', {}, id),
                  createDOMElement('td', {}, firstName),
                  createDOMElement('td', {}, lastName),
                  createDOMElement('td', {}, facultyNumber),
                  createDOMElement('td', {}, grade),
      );
      fragment.appendChild(tr);
    });
  
    html.tbody().innerHTML = '';
    html.tbody().appendChild(fragment);
  }
}

export { html, constructTable };
