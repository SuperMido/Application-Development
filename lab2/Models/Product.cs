using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
    }
}