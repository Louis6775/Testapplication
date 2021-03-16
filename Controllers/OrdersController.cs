using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TestApplication.Data;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly Context _context;

        public OrdersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpPost("Makeorder")]
        public async Task<ActionResult<IEnumerable<MakeOrderDTO>>> Makeorder(MakeOrderDTO request)
        {
            foreach(var item in request.Products)
            {
                var order = new Orders()
                {
                    Customer_id = request.Customer_id,
                    Product_id = item,
                    price = request.price
                };
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("MakeOrder",request);
        }

        /* [HttpPost("return")]
        public async Task<ActionResult<IEnumerable<LoanBookDTO>>> ReturnBook(ReturnBookDTO request)
        {
            foreach(var item in request.Id)
            {
                var library_item = await _context.Library.SingleOrDefaultAsync(x => x.Id == item);
                library_item.Return_date = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetLibraryBooks",request);
        }

        [HttpPost("renew")]
        public async Task<ActionResult<IEnumerable<AddBook>>> Renew(ReturnBookDTO request)
        {
            foreach(var item in request.Id)
            {
                var library_item = await _context.Library.SingleOrDefaultAsync(x => x.Id == item);
                library_item.Renewed = library_item.Renewed + 1;
                await _context.SaveChangesAsync();
            }
            
            return CreatedAtAction("GetLibraryBooks",request);
        } */
    }
}