function loadRepos() {
  let username = document.getElementById('username');
  let repos = document.getElementById('repos');

  const url = `https://api.github.com/users/${username.value}/repos`;

  fetch(url)
    .then(x => x.json())
    .then(data => {
      repos.innerHTML = data.map(x => `<li><a href="${x.html_url}">${x.full_name}</a></li>`).join('');
    });
}