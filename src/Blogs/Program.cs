using System;
using System.Linq;
using MongoDB.Driver;

namespace Blogs
{
  class Program
  {
    static void Main(string[] args)
    {
      const string ConnectionString = "mongodb://localhost";
      var server = MongoServer.Create(ConnectionString);
      var blog = server.GetDatabase("blog");
      var posts = blog.GetCollection<Post>("posts");

      var firstPost = new Post("First post!", "Welcome to my blog");
      firstPost.Comments.Add("First comment!");

      posts.Save(firstPost);

      // Will only return posts where Title = "First post!"
      //var matchingPosts = posts.Find(Query.EQ("Title", firstPost.Title)); 
      
      var matchingPosts = posts.FindAll();
      foreach (var matchingPost in matchingPosts)
      {
        Console.WriteLine(matchingPost);
        if (matchingPost.Comments != null)
          Console.WriteLine(matchingPost.Comments.ElementAt(0));
      }
    }
  }
}
