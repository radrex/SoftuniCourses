function solve(path) {
  let file = path.substring(path.lastIndexOf('\\') + 1);

  let fileName = file.substring(0, file.lastIndexOf('.'));
  let extension = file.substring(file.lastIndexOf('.') + 1);

  console.log(`File name: ${fileName}`);
  console.log(`File extension: ${extension}`);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('C:\\Internal\\training-internal\\Template.pptx');
solve('C:\\Projects\\Data-Structures\\LinkedList.cs');
