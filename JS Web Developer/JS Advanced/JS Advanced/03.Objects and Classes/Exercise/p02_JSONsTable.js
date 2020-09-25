function solve(input = []) {
  let html = '<table>\n';

  for (const json of input) {
    let obj = JSON.parse(json);

    html += '\t<tr>\n';
    Object.keys(obj).forEach(x => html += `\t\t<td>${obj[x].toString()
                                                           .replace(/&/g, "&amp;")
                                                           .replace(/</g, "&lt;")
                                                           .replace(/>/g, "&gt;")
                                                           .replace(/"/g, "&quot;")
                                                           .replace(/'/g, "&#39;")}</td>\n`);
    html += '\t</tr>\n';
  }

  return html += '</table>'
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
                   '{"name":"Teo","position":"Lecturer","salary":1000}',
                   '{"name":"Georgi","position":"Lecturer","salary":1000}']));
