function solve(arr = []) {
  let phoneBook = {};
  while (arr.length !== 0) {
    let [person, phone] = arr.shift().split(' ');
    phoneBook[person] = phone;
  }

  Object.entries(phoneBook).forEach(person => console.log(`${person[0]} -> ${person[1]}`));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Tim 0834212554',
       'Peter 0877547887',
       'Bill 0896543112',
       'Tim 0876566344']);
