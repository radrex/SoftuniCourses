function storeUniqueSequences(arr = []) {
  for (let i = 0; i < arr.length; i++) {
    arr[i] = JSON.parse(arr[i]).sort((a, b) => b - a);
  }

  for (let i = 0; i < arr.length - 1; i++) {
    let sortedString = arr[i].toString();

    for (let j = i + 1; j < arr.length; j++) {
      let sortedString2 = arr[j].toString();
      
      if (sortedString === sortedString2) {
        arr.splice(j, 1);
        j--;
      }
    }
  }

  arr.sort((a, b) => a.length - b.length);

  for (let item of arr) {
    console.log(`[${item.join(', ')}]`);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
storeUniqueSequences(["[-3, -2, -1, 0, 1, 2, 3, 4]",
                     "[10, 1, -17, 0, 2, 13]",
                     "[4, -3, 3, -2, 2, -1, 1, 0]"]);

storeUniqueSequences(["[7.14, 7.180, 7.339, 80.099]",
                      "[7.339, 80.0990, 7.140000, 7.18]",
                      "[7.339, 7.180, 7.14, 80.099]"]);

