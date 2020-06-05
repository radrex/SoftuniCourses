function reverse(n, array) {
  let arr = [];
  for (let i = 0; i < n; i++) {
    arr.push(array.shift());
  }

  let reversed = '';
  for (let i = arr.length - 1; i >= 0; i--) {
    reversed += arr[i] + ' ';
  }

  reversed = reversed.trimEnd();
  console.log(reversed);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
reverse(3, [10, 20, 30, 40, 50]);
reverse(4, [-1, 20, 99, 5]);
reverse(2, [66, 43, 75, 89, 47]);
