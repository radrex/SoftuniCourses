import { Data } from "./data.js";
import { displayPosts, displayPost } from "./views.js";
import { withCache } from "./withCache.js";

const baseUrl = 'https://blog-apps-c12bf.firebaseio.com/';
const constructUrl = x => `${baseUrl}${x}/.json`;

const data = new Data('https://blog-apps-c12bf.firebaseio.com/', function(x){ return `${this.baseUrl}${x}/.json`}, withCache);

const actions = {
  btnLoadPosts: async () => {
    let posts = await data.getPosts();
    displayPosts().then(html, posts);
  },
  btnViewPost: async () => {
    const post = await data.getPost(html.select().value);
    const comments = await data.getComments();
    displayPost(html, comments, post);
  },
};

function handleEvent(evt) {
  if (typeof actions[evt.target.id] === 'function') {
    actions[evt.target.id]();
  }
}

const html = {
  select: () => document.getElementById('posts'),
  title: () => document.getElementById('post-title'),
  body: () => document.getElementById('post-body'),
  comments: () => document.getElementById('post-comments'),
};

function attachEvents() {
  document.addEventListener('click', handleEvent);
}

attachEvents();