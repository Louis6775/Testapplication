using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public int Product_id { get; set; }

        public int price { get; set;}
    }
}