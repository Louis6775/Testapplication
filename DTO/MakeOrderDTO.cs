using System.Collections.Generic;

namespace DTO
{
    public class MakeOrderDTO
    {
        public int Customer_id { get; set; }
        public List<int> Products {get; set;}
        public int price { get; set;}
    }
}