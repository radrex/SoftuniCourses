import { html, constructTable } from "./dom.js";
const baseUrl = 'https://remotedb-55dd4.firebaseio.com/';

//----------- ERROR HANDLING and DATA PARSE -----------
function handleError(response) {
  if (!response.ok) {
    throw new Error(response.statusText);
  }
  return response;
}

function deserializeData(response) { return response.json(); }

//--------------------- DATA CRUD ---------------------
function fetchBooks() {
  fetch(`${baseUrl}Books.json`)
  .then(handleError)
  .then(deserializeData)
  .then(constructTable)
  .catch(err => console.log(err));
}

function addBook() {
  let title = html.bookTitle();
  let author = html.bookAuthor();
  let isbn = html.bookIsbn();

  if (title.value !== '' && author.value !== '' && isbn.value !== '') {
    fetch(`${baseUrl}Books.json`, {
      method: 'POST',
      headers: { 'Content-type': 'application/json' },
      body: JSON.stringify({ "title": title.value, "author": author.value, "isbn": isbn.value }),
    })
    .then(fetchBooks)
    .catch(err => console.log(err));

    title.value = '';
    author.value = '';
    isbn.value = '';
  }
}

function loadBookForEdit(element) {
  let [titleTd, authorTd, isbnTd, buttonsTd] = [...element.parentElement.parentElement.children];
  html.bookTitle().value = titleTd.textContent;
  html.bookAuthor().value = authorTd.textContent;
  html.bookIsbn().value = isbnTd.textContent;

  let editBtn = html.submit();
  editBtn.textContent = 'Edit Book';
  editBtn.setAttribute('data-key', buttonsTd.firstElementChild.getAttribute('data-key'));
}

function editBook(element) {
  let title = html.bookTitle();
  let author = html.bookAuthor();
  let isbn = html.bookIsbn();

  if (title.value !== '' && author.value !== '' && isbn.value !== '') {
    fetch(`${baseUrl}Books/${element.getAttribute('data-key')}.json`, {
      method: 'PATCH',
      headers: { 'Content-type': 'application/json' },
      body: JSON.stringify({ "title": title.value, "author": author.value, "isbn": isbn.value }),
    })
    .then(fetchBooks)
    .catch(err => console.log(err));
  }

  title.value = '';
  author.value = '';
  isbn.value = '';
  html.submit().textContent = 'Submit';
  html.submit().removeAttribute('data-key');
}

function deleteBook(element) {
  fetch(`${baseUrl}Books/${element.getAttribute('data-key')}.json`, { method: 'DELETE' });
  element.parentElement.parentElement.remove();
}

export { fetchBooks, addBook, loadBookForEdit, editBook, deleteBook };