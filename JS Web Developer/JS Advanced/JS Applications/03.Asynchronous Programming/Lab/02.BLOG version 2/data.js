import { fetchData } from "./genericFetch.js";

export class Data {
  myFetch;
  baseUrl;
  urlTemplate;

  constructor(baseUrl, urlTemplate, withCache) {
    this.baseUrl = baseUrl;
    this.urlTemplate = urlTemplate.bind(this);
    this.myFetch = withCache(fetchData.bind(window, undefined, undefined), 10000);
  }

  getPosts() {
    return this.myFetch(this.urlTemplate('posts'));
  }

  getPost(id) {
    return this.myFetch(this.urlTemplate(`posts/${id}`));
  }

  getComments() {
    return this.myFetch(this.urlTemplate('comments'));
  }
}
