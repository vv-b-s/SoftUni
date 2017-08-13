using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Task
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public string Title { set; get; }

        public string Comments { set; get; }

        public Task() { }
        public Task(string title, string comments)
        {
            Title = title;
            Comments = comments;
        }
    }
}