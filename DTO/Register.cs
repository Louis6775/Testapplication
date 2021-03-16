using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Register : StudentDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}