namespace Forum
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using var context = new ForumDbContext();
            ResetDatabase(context);

            //var categories = context.Categories
            //                        .Include(c => c.Posts)
            //                        .ThenInclude(p => p.Author)
            //                        .Include(c => c.Posts)
            //                        .ThenInclude(p => p.Replies)
            //                        .ThenInclude(r => r.Author)
            //                        .ToArray();

            var categories = context.Categories
                                    .Select(c => new
                                    {
                                        Name = c.Name,
                                        Posts = c.Posts.Select(p => new
                                        {
                                            Title = p.Title,
                                            Content = p.Content,
                                            AuthorUsername = p.Author.Username,
                                            Replies = p.Replies.Select(r => new
                                            {
                                                Content = r.Content,
                                                AuthorUsername = r.Author.Username
                                            }),
                                            Tags = p.Tags.Select(t => t.Tag.Name)
                                            .ToArray()
                                        })
                                        .ToArray()
                                    })
                                    .ToArray();

            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Name} ({category.Posts.Count()})");
                foreach (var post in category.Posts)
                {
                    Console.WriteLine($"--{post.Title}: {post.Content}");
                    Console.WriteLine($"--by {post.AuthorUsername}");

                    Console.WriteLine("Tags: " + String.Join(", ", post.Tags));

                    foreach (var reply in post.Replies)
                    {
                        Console.WriteLine($"----{reply.Content} from {reply.AuthorUsername}");
                    }
                }
            }
        }

        private static void ResetDatabase(ForumDbContext context)
        {
            context.Database.EnsureDeleted(); // Delete db everytime, not advisable for larger databases...
            context.Database.Migrate();
            Seed(context);
        }

        private static void Seed(ForumDbContext context)
        {
            var users = new[]
            {
                new User("gosho", "123"),
                new User("pesho", "123"),
                new User("ivan", "123"),
                new User("merry", "123")
            };
            context.Users.AddRange(users);

            var categories = new[]
            {
                new Category
                {
                    Name = "C#"
                },
                new Category
                {
                    Name = "Support"
                },
                new Category
                {
                    Name = "Python"
                },
            };
            context.Categories.AddRange(categories);

            var posts = new[]
            {
                new Post
                {
                    Title = "C# Rulz",
                    Content = "Some content",
                    Category = categories[0],
                    Author = users[0],
                },
                new Post
                {
                    Title = "Python Rulz",
                    Content = "Python content",
                    Category = categories[2],
                    Author = users[1],
                },
                new Post
                {
                    Title = "Supporting",
                    Content = "Supporting is underrated",
                    Category = categories[1],
                    Author = users[2],
                },
            };
            context.Posts.AddRange(posts);

            var replies = new[]
            {
                new Reply
                {
                    Content = "Turn it on",
                    Post = posts[2],
                    Author = users[0],
                },
                new Reply
                {
                    Content = "Yep",
                    Post = posts[0],
                    Author = users[3],
                },
            };
            context.Replies.AddRange(replies);

            var tags = new[]
            {
                new Tag { Name = "C#"},
                new Tag { Name = "Programming"},
                new Tag { Name = "Praise"},
                new Tag { Name = "Microsoft"},
            };

            var postTags = new[]
            {
                new PostTag
                {
                    PostId = 1,
                    Tag = tags[0],
                },
                new PostTag
                {
                    PostId = 1,
                    Tag = tags[1],
                },
                new PostTag
                {
                    PostId = 1,
                    Tag = tags[2],
                },
                new PostTag
                {
                    PostId = 1,
                    Tag = tags[3],
                }
            };

            context.PostsTags.AddRange(postTags);

            context.SaveChanges();
        }
    }
}
