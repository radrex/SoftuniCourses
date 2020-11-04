function loadRepos() {
  let btn = document.getElementsByTagName('button')[0];

  btn.addEventListener('click', function loadRepos() {
    let url = 'https://api.github.com/users/testnakov/repos';
    const httpRequest = new XMLHttpRequest();
    
    httpRequest.addEventListener('readystatechange', function () {
      if (httpRequest.readyState === 4 && httpRequest.status === 200) {
        document.getElementById("res").textContent = httpRequest.responseText;
      }
    });
    httpRequest.open("GET", url);
    httpRequest.send();
  });
}