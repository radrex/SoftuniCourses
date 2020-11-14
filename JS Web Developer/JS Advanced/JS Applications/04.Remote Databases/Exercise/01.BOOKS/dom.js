const html = {
  tbody: () => document.getElementById('tbody'),
  loadBooks: () => document.getElementById('loadBooks'),
  bookTitle: () => document.getElementById('title'),
  bookAuthor: () => document.getElementById('author'),
  bookIsbn: () => document.getElementById('isbn'),
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
  let fragment = new DocumentFragment();
  Object.entries(json).forEach(([key, {title, author, isbn}]) => {
    let tr = createDOMElement('tr', {}, '', 
                createDOMElement('td', {}, title),
                createDOMElement('td', {}, author),
                createDOMElement('td', {}, isbn),
                createDOMElement('td', {}, '', 
                  createDOMElement('button', { 'data-key': key}, 'Edit'),
                  createDOMElement('button', { 'data-key': key}, 'Delete'))
    );
    fragment.appendChild(tr);
  });

  html.tbody().innerHTML = '';
  html.tbody().appendChild(fragment);
}

export { html, constructTable };