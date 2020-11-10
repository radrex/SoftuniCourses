function loadCommits() {
  let username = document.getElementById('username');
  let repo = document.getElementById('repo');
  let ul = document.getElementById('commits');

  if (username == null || repo == null || ul == null) {
    throw new Error('Something went wrong...');
  }

  fetch(`https://api.github.com/repos/${username.value}/${repo.value}/commits`)
    .then(response => {
      if (response.status === 404) {
        throw new Error(`<li>${response.status} (${response.statusText})</li>`);
      }
      return response;
    })
    .then(response => response.json())
    .then(commits => {
      ul.innerHTML = commits.map(x => `<li>${x.commit.author.name}: ${x.commit.message}</li>`).join('');
    })
    .catch(err => {
      ul.innerHTML = err.message;
    });
}