using System.ComponentModel.DataAnnotations;

namespace TestApplication3.DTO
{
    public class AddCustomer
    {
        [Required]
        public string name { get; set; }
    }
}