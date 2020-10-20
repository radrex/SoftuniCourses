function solve(data, criteria) {
  let jsonObj = JSON.parse(data);

  function printEmployees(employees) {
    return employees.reduce((acc, emp, idx) => acc += `${idx}. ${emp.first_name} ${emp.last_name} - ${emp.email}\n`, '')
  }

  let getEmployeesById = (id) => printEmployees(jsonObj.filter(x => x.id === id));
  let getEmployeesByFirstName = (firstName) => printEmployees(jsonObj.filter(x => x.first_name === firstName));
  let getEmployeesByLastName = (lastName) => printEmployees(jsonObj.filter(x => x.last_name === lastName));
  let getEmployeesByEmail = (email) => printEmployees(jsonObj.filter(x => x.email === email));
  let getEmployeesByGender = (gender) => printEmployees(jsonObj.filter(x => x.gender === gender));
  let getAllEmployees = () => printEmployees(jsonObj);

  const actions = {
    'id': getEmployeesById,
    'first_name': getEmployeesByFirstName,
    'last_name': getEmployeesByLastName,
    'email': getEmployeesByEmail,
    'gender': getEmployeesByGender,
    'all': getAllEmployees,
  };

  let [key, value] = criteria.split('-');
  return actions[key](value).trim();
}

// Don't copy the code below in judge, you won't get any points, just the code above
console.log(solve(`[{
  "id": "1",
  "first_name": "Ardine",
  "last_name": "Bassam",
  "email": "abassam0@cnn.com",
  "gender": "Female"
}, {
  "id": "2",
  "first_name": "Kizzee",
  "last_name": "Jost",
  "email": "kjost1@forbes.com",
  "gender": "Female"
},  
{
  "id": "3",
  "first_name": "Evanne",
  "last_name": "Maldin",
  "email": "emaldin2@hostgator.com",
  "gender": "Male"
}]`, 
'gender-Female'));

console.log(solve(`[{
  "id": "1",
  "first_name": "Kaylee",
  "last_name": "Johnson",
  "email": "k0@cnn.com",
  "gender": "Female"
}, {
  "id": "2",
  "first_name": "Kizzee",
  "last_name": "Johnson",
  "email": "kjost1@forbes.com",
  "gender": "Female"
}, {
  "id": "3",
  "first_name": "Evanne",
  "last_name": "Maldin",
  "email": "emaldin2@hostgator.com",
  "gender": "Male"
}, {
  "id": "4",
  "first_name": "Evanne",
  "last_name": "Johnson",
  "email": "ev2@hostgator.com",
  "gender": "Male"
}]`,
'last_name-Johnson'));
