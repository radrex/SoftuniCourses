function attachEvents() {
  let loadBtn = document.getElementById('btnLoadPosts');
  let postsSelect = document.getElementById('posts');
  let viewBtn = document.getElementById('btnViewPost');
  let postTitle = document.getElementById('post-title');
  let postBody = document.getElementById('post-body');
  let postComments = document.getElementById('post-comments');

  if (loadBtn == null || postsSelect == null || viewBtn == null || postTitle == null || postBody == null || postComments == null) {
    throw new Error('Something went wrong...');
  }

  let baseUrl = 'https://blog-apps-c12bf.firebaseio.com/';

  loadBtn.addEventListener('click', function() {
    fetch(baseUrl.concat('posts.json'))
      .then(response => response.json())
      .then(posts => {
        postsSelect.innerHTML = Object.keys(posts).map(key => `<option value="${key}">${posts[key].title}</option>`).join('');
      })
      .catch(err => console.log(err.message));
  });

  viewBtn.addEventListener('click', function() {
    if (postsSelect.value !== '') {
      let postId;
      fetch(baseUrl.concat(`posts/${postsSelect.value}.json`))
        .then(x => x.json())
        .then(post => {
          postTitle.textContent = post.title;
          postBody.textContent = post.body;
          postId = post.id;
          return fetch(baseUrl.concat('comments.json'));
        })
        .then(x => x.json())
        .then(posts => {
          postComments.innerHTML = Object.values(posts).filter(x => x.postId === postId).map(x => `<li>${x.text}</li>`).join('');
        })
        .catch(err => console.log(err.message));
    }
  });

  /* Async/Await
      viewBtn.addEventListener('click', async function() {
      if (postsSelect.value !== '') {
        let postId;
        
        let post = await (await fetch(baseUrl.concat(`posts/${postsSelect.value}.json`))).json();
        let comments = await (await fetch(baseUrl.concat('comments.json'))).json();

        postTitle.textContent = post.title;
        postBody.textContent = post.body;
        postId = post.id;

        postComments.innerHTML = Object.values(comments).filter(x => x.postId === postId).map(x => `<li>${x.text}</li>`).join('');
      }
    });
  */
}

attachEvents();