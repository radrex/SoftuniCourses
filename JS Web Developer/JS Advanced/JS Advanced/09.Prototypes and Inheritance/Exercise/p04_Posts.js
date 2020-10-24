function posts() {
  //----------- BASE CLASS -----------
  class Post {
    constructor(title, content) {
      this.title = title;
      this.content = content;
    }

    toString() {
      return `Post: ${this.title}\nContent: ${this.content}`;
    }
  }

  //----------- CHILD CLASS -----------
  class SocialMediaPost extends Post {
    constructor(title, content, likes, dislikes) {
      super(title, content);
      this.likes = likes;
      this.dislikes = dislikes;
      this.comments = [];
    }

    addComment(comment) {
      this.comments.push(comment);
    }

    toString() {
      let message = `${super.toString()}\nRating: ${this.likes - this.dislikes}`;
      if (this.comments.length !== 0) {
        message += '\nComments:';
        this.comments.forEach(x => message += `\n * ${x}`);
      }
      return message;
    }
  }

  //----------- CHILD CLASS -----------
  class BlogPost extends Post {
    constructor(title, content, views) {
      super(title, content);
      this.views = views;
    }

    view() {
      this.views++;
      return this;
    }

    toString() {
      return `${super.toString()}\nViews: ${this.views}`;
    }
  }

  return { Post, SocialMediaPost, BlogPost };
}

// Don't copy the code below in judge, you won't get any points, just the code above
let postClasses = posts();

let post = new postClasses.Post("Post", "Content");
console.log(post.toString()); // Post: Post
                              // Content: Content

let scm = new postClasses.SocialMediaPost("TestTitle", "TestContent", 25, 30);
scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");
console.log(scm.toString());  // Post: TestTitle
                              // Content: TestContent
                              // Rating: -5
                              // Comments:
                              //  * Good post
                              //  * Very good post
                              //  * Wow!