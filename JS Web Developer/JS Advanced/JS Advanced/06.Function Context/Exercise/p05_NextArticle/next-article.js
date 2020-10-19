function getArticleGenerator(articles) {
  let divElement = document.getElementById('content');
  if (divElement == null) {
    throw new Error('Something went wrong...');
  }

  return function showNext() {
    if (articles.length > 0) {
      let article = document.createElement('article');
      article.textContent = articles.shift();
      divElement.appendChild(article);
    }
  }
}