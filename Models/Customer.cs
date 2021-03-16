using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }

    }
}