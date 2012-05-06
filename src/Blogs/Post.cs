using System.Collections.Generic;
using MongoDB.Bson;

namespace Blogs
{
  public class Post
  {
    public Post(string title, string content)
    {
      Id = new ObjectId();
      Title = title;
      Content = content;
      Comments = new List<string>();
    }

    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public IList<string> Comments { get; set; } 
    
    public override string ToString()
    {
      return string.Format("ID: {0}, Title: {1}, Content: {2}", Id, Title, Content);
    }
  }
}