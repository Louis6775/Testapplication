using Models;

namespace TestApplication.DTO
{
    public class ProductDTO : Library
    {
        public decimal price { get; set; }
        public string name { get; set; }
    }
}