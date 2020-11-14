import { fetchBooks, addBook, loadBookForEdit, editBook, deleteBook } from "./data.js";

const actions = {
  'LOAD ALL BOOKS': () => fetchBooks(),
  'Submit': () => addBook(),
  'Edit': (element) => loadBookForEdit(element),
  'Delete': (element) => deleteBook(element),
  'Edit Book': (element) => editBook(element),
};

document.addEventListener('click', function(evt) {
  evt.preventDefault();
  if (evt.target && evt.target.nodeName === "BUTTON") {
    actions[evt.target.textContent](evt.target);
  }
});
