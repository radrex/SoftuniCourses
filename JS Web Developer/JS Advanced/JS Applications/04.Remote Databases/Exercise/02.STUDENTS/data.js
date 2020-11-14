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
function fetchStudents() {
  fetch(`${baseUrl}Students.json`)
  .then(handleError)
  .then(deserializeData)
  .then(constructTable)
  .catch(err => console.log(err));
}

function addStudent() {
  let firstName = html.studentFirstName();
  let lastName = html.studentLastName();
  let facultyNumber = html.facultyNumber();
  let grade = html.grade();

  if (firstName.value !== '' && lastName.value !== '' && facultyNumber.value !== '' && grade.value !== '' && grade.value >= 2.00 && grade.value <= 6.00) {
    fetch(`${baseUrl}Students.json`)
      .then(x => x.json())
      .then(x => {
        let id = x == null ? 1 : Object.keys(x).length+1;
        fetch(`${baseUrl}Students.json`, {
          method: 'POST',
          headers: { 'Content-type': 'application/json' },
          body: JSON.stringify({ "id": id, "firstName": firstName.value, "lastName": lastName.value, "facultyNumber": facultyNumber.value, "grade": grade.value }),
        })
        .then(fetchStudents);

        firstName.value = '';
        lastName.value = '';
        facultyNumber.value = '';
        grade.value = '';
      })
      .catch(err => console.log(err));
  }
}

export { fetchStudents, addStudent };