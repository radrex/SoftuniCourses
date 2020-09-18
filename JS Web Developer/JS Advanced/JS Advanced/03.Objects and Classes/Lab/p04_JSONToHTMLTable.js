function solve(jsonString) {
  let result = '<table>\n';

  const arr = JSON.parse(jsonString);
  const titleSet = new Set(arr.map(i => Object.keys(i)).flat());
  const titleArray = Array.from(titleSet);

  result += '<tr><th>' + titleArray.join('</th><th>') + '</th></tr>';
  result = arr.reduce((acc, currentItem) => {
    let innerResult = titleArray.reduce((titleAcc, currentTitle) => {
      let value = currentItem[currentTitle];
      value = value === undefined ? '' : value.toString().replace(/&/g, "&amp;")
                                                         .replace(/</g, "&lt;")
                                                         .replace(/>/g, "&gt;")
                                                         .replace(/"/g, "&quot;")
                                                         .replace(/'/g, "&#39;");
      return titleAcc + '<td>' + value + '</td>';
    }, '');

    if (innerResult === '') {
      return acc;
    }

    return acc + '\n<tr>' + innerResult + '</tr>';
  }, result);

  result = result + '\n</table>';
  return result;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']));
console.log(solve(['[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]']));
