let baseUrl = 'https://remotedb-55dd4.firebaseio.com/';

const html = {
  tbody: () => document.getElementById('table-body'),
};

fetch(`${baseUrl}Books.json`)
  .then(handleError)
  .then(deserializeData)
  .then(constructTable)
  .catch(handleError);

function constructTable(x) {
  let fragment = new DocumentFragment();
  Object.values(x).map(({author, title}) => {
    let tr = document.createElement('tr');
    let tdAuthor = document.createElement('td');
    tdAuthor.textContent = author;

    let tdTitle = document.createElement('td');
    tdTitle.textContent = title;

    tr.appendChild(tdAuthor);
    tr.appendChild(tdTitle);
    fragment.appendChild(tr);
  });

  html.tbody().appendChild(fragment);
}

function handleError(x) {
  if (!x.ok) {
    throw new Error(x.statusText);
  }
  return x;
}

function deserializeData(x) { return x.json(); }

//TODO: implement CRUD operations