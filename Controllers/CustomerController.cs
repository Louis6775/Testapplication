using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TestApplication.Data;
using TestApplication.DTO;
using TestApplication3.DTO;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly Context _context;
        public CustomerController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customer = from Customer in _context.Customer
            select new CustomerDTO {
                name = Customer.name
            };

            return await customer.ToListAsync();
        }



         [HttpPost]
         public async Task<ActionResult> Add_Customers(AddCustomer customerDTO)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             var customer = new Customer()
             {
                 name = customerDTO.name
             };
             await _context.Customer.AddAsync(customer);
             await _context.SaveChangesAsync();

             await _context.SaveChangesAsync();

             return CreatedAtAction("GetStudents", new { id = customer.Id }, customerDTO);
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

        // [HttpPut("{id}")]
        // public async Task<ActionResult> Update_Students(int id, StudentDTO student)
        // {
        //     if (id != student.studentId || !StudentExists(id))
        //     {
        //         return BadRequest();
        //     }
        //     else
        //     {
        //         var students = _context.Students.SingleOrDefault(x => x.id == id);
        //         var students_description = _context.Students_Description.SingleOrDefault(x => x.studentId == id);
        //         students.id = student.studentId;
        //         students.grade = student.grade;
        //         students_description.firstName = student.firstName;
        //         students_description.lastName = student.lastName;
        //         students_description.age = student.age;
        //         students_description.adress = student.adress;
        //         students_description.country = student.country;
        //         await _context.SaveChangesAsync();
        //         return NoContent();
        //     }
        // }

        // private bool StudentExists(int id)
        // {
        //     return _context.Students.Any(x => x.id == id);
        // }
    }
}