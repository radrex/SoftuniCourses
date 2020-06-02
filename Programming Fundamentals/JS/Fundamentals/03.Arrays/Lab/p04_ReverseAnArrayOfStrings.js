function reverse(elements) {
  for (let i = 0; i < elements.length / 2; i++) {
    swapElements(elements, i, elements.length - 1 - i);
  }

  console.log(elements.join(' '));

  function swapElements(arr, i, j) {
    let tempValue = arr[i];
    arr[i] = arr[j];
    arr[j] = tempValue;
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
reverse(['a', 'b', 'c', 'd', 'e']);
reverse(['abc', 'def', 'hig', 'klm', 'nop']);
reverse(['33', '123', '0', 'dd']);
