function createArticle() {
  //----------- GET DATA -----------
  let input = document.getElementById('createTitle');
  let textarea = document.getElementById('createContent');
  let section = document.getElementById('articles');

  if (input === null || textarea === null || section === null) {
    throw new Error('Something is wrong...');
  }

  if (input.value === '' || textarea.value === '') {
    return;
  }

  //-------- CONSTRUCT HTML --------
  let article = document.createElement('article');
  let h3 = document.createElement('h3');
  let p = document.createElement('p');
  article.appendChild(h3);
  article.appendChild(p);
  section.appendChild(article);

  //----------- FILL HTML ----------
  h3.innerHTML = input.value;
  p.innerHTML = textarea.value;

  //----------- CLEAR INPUT FIELDS ----------
  input.value = '';
  textarea.value = '';
}
