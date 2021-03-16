using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public decimal price { get; set; }
        public string name { get; set; }
    }
}