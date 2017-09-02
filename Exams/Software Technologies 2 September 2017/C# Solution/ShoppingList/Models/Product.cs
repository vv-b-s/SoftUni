using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShoppingList.Models
{
    public class Product
    {
        [Key]
        public int Id {set; get;}
        
        [Required]
        public int Priority {set; get;}
        
        [Required]
        public string Name {set; get;}
        
        [Required]
        public int Quantity { set; get; }

        [Required]
        public string Status { get; set; }

        public Product(){}
        public Product(int priority, string name, int quantity, string status)
        {
            Priority = priority;
            Name = name;
            Quantity = quantity;
            Status = status;
        }
    }
}