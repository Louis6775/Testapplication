using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string grade { get; set; }
        public string username { get; set; }
        public byte[] passwordhash { get; set; }
        public byte[] passwordsalt { get; set; }

    }
}