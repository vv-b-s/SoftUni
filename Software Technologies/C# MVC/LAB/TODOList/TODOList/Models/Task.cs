using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TODOList.Models
{
    public class Task
    {
        public int Id { set; get; }

        [Required]
        public string Title { set; get; }
    }
}