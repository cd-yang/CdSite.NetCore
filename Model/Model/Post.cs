using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AspNetCoreTodo.Model.Model
{
    /// <summary>
    /// ����
    /// </summary>
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //public List<string> Tags { get; set; } // ��Ҫ��һ�ű�洢 List
        public DateTime CreateTime { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }

    /// <summary>
    /// ����
    /// </summary>
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Post> Posts { get; set; }
    }
}