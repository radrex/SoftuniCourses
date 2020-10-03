function solve() {
  //----------- GET DATA -----------
  let p = document.getElementById('input');
  let div = document.getElementById('output');

  if (p === null || div === null) {
    throw new Error('Something went wrong...');
  }

  //-------- CONSTRUCT AND FILL HTML --------
  let sentences = p.innerHTML.split('.').filter(x => x !== "");
  for (let i = 0; i < sentences.length; i += 3) {
    let paragraph = document.createElement('p');
    let str = '';
    for (let j = 0; j < 3; j++) {
      if (i + j < sentences.length) {
        str += sentences[i + j] + '.';
      }
    }

    paragraph.innerHTML = str;
    div.appendChild(paragraph);
  }
}