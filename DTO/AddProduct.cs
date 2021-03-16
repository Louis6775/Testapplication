using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class AddProduct
    {
        [Required]
        public string name { get; set; }
        [Required]
        public decimal price { get; set; }
    }
}