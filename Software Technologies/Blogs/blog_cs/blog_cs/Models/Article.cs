using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace blog_cs.Models
{
    public class Article
    {
        [Key]
        public int Id { set; get; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public string Content { get; set; }     // has no restrictions so it can be without any attributes

        public virtual ApplicationUser Author { set; get; }

        [ForeignKey("Author")]              // Gets the key from Author
        public string AuthorId { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsAuthor(string name) => this.Author.UserName.Equals(name);
    }
}