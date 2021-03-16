using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TestApplication.Data;
using TestApplication.DTO;
using TestApplication.Models;
using TestApplication3.DTO;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var product = from Product in _context.Product
            select new ProductDTO {
                name = Product.name,
                price = Product.price
            };

            return await product.ToListAsync();
        }



         [HttpPost]
         public async Task<ActionResult> Add_Products(AddProduct ProductDTO)
         {
             if (!ModelState.IsValid)
             {
                return BadRequest(ModelState);
             }

             var product = new Product()
             {
                name = ProductDTO.name,
                price = ProductDTO.price
             };
             await _context.Product.AddAsync(product);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetProducts", new { id = product.id }, ProductDTO);
         }


        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Student>> Delete_Students(int id)
        // {
        //     var student = _context.Students.Find(id);
        //     var student_description = _context.Students_Description.SingleOrDefault(x => x.studentId == id);

        //     if (student == null)
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         _context.Remove(student);
        //         _context.Remove(student_description);
        //         await _context.SaveChangesAsync();
        //         return student;
        //     }
        // }

         [HttpPut("{id}")]
         public async Task<ActionResult> Update_Students(int id, ProductDTO product)
         {
             if (id != product.Id || !ProductExists(id))
             {
                 return BadRequest();
             }
             else
             {
                 var product2 = _context.Product.SingleOrDefault(x => x.id == id);
                 product2.id = id;
                 product2.price = product.price;
                 product2.name  =product.name;
                 await _context.SaveChangesAsync();
                 return NoContent();
             }
         }

         private bool ProductExists(int id)
         {
             return _context.Product.Any(x => x.id == id);
         }
    }
}