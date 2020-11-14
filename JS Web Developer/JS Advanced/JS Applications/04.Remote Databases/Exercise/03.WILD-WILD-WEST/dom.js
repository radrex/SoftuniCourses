const html = {
  players: () => document.getElementById('players'),
  player: () => document.getElementById('addName'),
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

function constructDiv(json) {
  if (json != null) {
    let fragment = new DocumentFragment();
    Object.entries(json).forEach(([key, {name, money, bullets}]) => {
      let div = createDOMElement('div', {class: 'player'}, '', 
                  createDOMElement('div', {class: 'row'}, '',
                    createDOMElement('label', {}, 'Name:'),
                    createDOMElement('label', {class: 'name'}, name)
                  ),
                  createDOMElement('div', {class: 'row'}, '',
                    createDOMElement('label', {}, 'Money:'),
                    createDOMElement('label', {class: 'money'}, money)
                  ),
                  createDOMElement('div', {class: 'row'}, '',
                    createDOMElement('label', {}, 'Bullets:'),
                    createDOMElement('label', {class: 'bullets'}, bullets)
                  ),
                  createDOMElement('button', {class: 'play', 'data-key': key}, 'Play'),
                  createDOMElement('button', {class: 'delete', 'data-key': key}, 'Delete'),
      );
      fragment.appendChild(div);
    });
  
    html.players().innerHTML = '';
    html.players().appendChild(fragment);
  }
}

export { html, constructDiv };