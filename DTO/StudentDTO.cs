using System.ComponentModel.DataAnnotations;

namespace TestApplication3.DTO
{
    public class StudentDTO
    {
        public int Student_id { get; set; }
        public string Grade { get; set; }
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