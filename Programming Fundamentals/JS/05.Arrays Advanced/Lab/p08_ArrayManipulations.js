function solve(tokens = []) {
  let arr = tokens.shift().split(' ').map(x => +x);

  for (let i = 0; i < tokens.length; i++) {
    let [command, num1, num2] = tokens[i].split(' '); // Destructuring
    num1 = +num1;
    num2 = +num2;

    switch (command) {
      case 'Add':       add(num1);            break;
      case 'Remove':    remove(num1);         break;
      case 'RemoveAt':  removeAt(num1);       break;
      case 'Insert':    insert(num1, num2);   break;

      default: break;
    }
  }
  console.log(arr.join(' '));
  
  function add(number) { arr.push(number); }
  function remove(number) { arr = arr.filter(x => x !== number); }
  function removeAt(index) { arr.splice(index, 1); }
  function insert(number, index) { arr.splice(index, 0, number); }
}

solve(['4 19 2 53 6 43',
       'Add 3',
       'Remove 2',
       'RemoveAt 1',
       'Insert 8 3']);

       
// function solve(tokens = []) {
//   //---- Adds the number after the last index of the array ----
//   const add = number => arr[arr.length] = number;

//   //---- Removes the first occurence of the given number from the array ----
//   const remove = number => {
//     for (let i = 0; i < arr.length; i++) {
//       if (arr[i] === number) {
//         for (let j = i; j < arr.length; j++) {
//           arr[j] = arr[j + 1];
//         }
//         arr.length = arr.length - 1;
//         return;
//       }
//     }
//   };

//   //---- Removes every occurence of the given number from the array ----
//   const removeAll = number => {
//     for (let i = 0; i < arr.length; i++) {
//       if (arr[i] === number) {
//         for (let j = i; j < arr.length; j++) {
//           arr[j] = arr[j + 1];
//         }
//         arr.length = arr.length - 1;
//         i--;
//       }
//     }
//   };

//   //---- Removes the element from the given index if such index exists ----
//   const removeAt = index => {
//     if (index < 0 || index > arr.length - 1) {
//       console.log('Index out of bound.');
//       return;
//     }

//     for (let i = index; i < arr.length; i++) {
//       arr[i] = arr[i + 1];
//     }
//     arr.length = arr.length - 1;
//   };

//   //---- Inserts the given number at the given index of the array ----
//   const insert = (number, index) => {
//     if (index < 0) {
//       console.log('Index out of bound.');
//       return;
//     }

//     for (let i = arr.length; i > index; i--) {
//       arr[i] = arr[i - 1];
//     }
//     arr[index] = number;
//   };

//   let arr = tokens.shift().split(' ').map(x => +x);

//   while (tokens.length !== 0) {
//     let command = tokens.shift().split(' ');
//     switch (command[0]) {
//       case 'Add': add(+command[1]); break;
//       case 'Remove': removeAll(+command[1]); break;
//       case 'RemoveAt': removeAt(+command[1]); break;
//       case 'Insert': insert(+command[1], +command[2]); break;

//       default: break;
//     }
//   }

//   console.log(arr.join(' '));
// }

// // Don't copy the calling of the function in judge, you won't get any points, just the code above
// solve(['4 19 2 53 6 43',
//        'Add 3',
//        'Remove 2',
//        'RemoveAt 1',
//        'Insert 8 3']);