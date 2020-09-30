function solve(jsonString) {
  let html = '<table>\n';
  let objArr = JSON.parse(jsonString);

  html += '\t<tr>';
  Object.keys(objArr[0]).forEach(x => html += `<th>${sanitizeString(x)}</th>`);
  html += '</tr>\n';

  objArr.forEach(x => {
    html += '\t<tr>';
    Object.values(x).forEach(y => html += `<td>${sanitizeString(y.toString())}</td>`);
    html += '</tr>\n';
  });

  return html += '</table>';
  
  //---------- FUNCTIONS ----------
  function sanitizeString(str) {
    return str.replace(/&/g, "&amp;")
              .replace(/</g, "&lt;")
              .replace(/>/g, "&gt;")
              .replace(/"/g, "&quot;")
              .replace(/'/g, "&#39;");
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['[{"name":"Pesho","score":479}, {"name":"Gosho","score":205}]']));
console.log(solve(['[{"name":"Pesho & Kiro","score":479}, {"name":"Gosho, Maria & Viki","score":205}]']));

//------------------------ WITH ONE LINER FUNCTIONS ------------------------
/*
  function solve(jsonString) {
    return generateTable(JSON.parse(jsonString));

    //---------- FUNCTIONS ----------
    function generateTable(objArray) { return `<table>\n${generateTableHeader(objArray[0])}${generateTableBody(objArray)}</table>`; }
    function generateTableHeader(obj) { return `\t<tr>${Object.keys(obj).map(x => `<th>${sanitizeString(x)}</th>`).join('')}</tr>\n`; }
    function generateTableBody(objArray) { return objArray.map(x => `\t<tr>${Object.values(x).map(y => `<td>${sanitizeString(y.toString())}</td>`).join('')}</tr>\n`).join(''); }
    
    function sanitizeString(str) {
      return str.replace(/&/g, "&amp;")
                .replace(/</g, "&lt;")
                .replace(/>/g, "&gt;")
                .replace(/"/g, "&quot;")
                .replace(/'/g, "&#39;");
    }
  }

  // Don't copy the calling of the function in judge, you won't get any points, just the code above
  console.log(solve(['[{"name":"Pesho","score":479}, {"name":"Gosho","score":205}]']));
  console.log(solve(['[{"name":"Pesho & Kiro","score":479}, {"name":"Gosho, Maria & Viki","score":205}]']));
*/
