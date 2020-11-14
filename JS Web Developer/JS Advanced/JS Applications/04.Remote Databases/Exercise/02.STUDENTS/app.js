import { fetchStudents, addStudent } from "./data.js";

const actions = {
  'Submit': () => addStudent(),
};

fetchStudents();

document.addEventListener('click', function(evt) {
  evt.preventDefault();
  if (evt.target && evt.target.nodeName === "INPUT") {
    actions[evt.target.value]();
  }
});
