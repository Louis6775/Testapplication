using System.ComponentModel.DataAnnotations;

namespace TestApplication3.DTO
{
    public class AddStudent
    {
        [Required]
        public string Grade { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }
    }
}