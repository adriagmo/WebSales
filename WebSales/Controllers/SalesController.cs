using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSales.Models;

namespace WebSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesTestContext _context;

        public SalesController(SalesTestContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSales()
        {
            return await _context.Sales.ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> GetSales(int id)
        {
            var sales = await _context.Sales.FindAsync(id);

            if (sales == null)
            {
                return NotFound();
            }

            return sales;
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSales(int id, Sales sales)
        {
            if (id != sales.IdSale)
            {
                return BadRequest();
            }

            _context.Entry(sales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sales
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sales>> PostSales(Sales sales)
        {
            _context.Sales.Add(sales);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSales", new { id = sales.IdSale }, sales);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sales>> DeleteSales(int id)
        {
            var sales = await _context.Sales.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sales);
            await _context.SaveChangesAsync();

            return sales;
        }

        [HttpGet("[action]/{IdSupp?}/{IdProd?}/{monthSince?}/{monthUntil?}")]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSalesSuppliers(int? IdSupp = null, int? IdProd = null,int? monthSince = null, int? monthUntil = null)
        {
            var Anio =  DateTime.Now.Year;
            monthSince = monthSince ??  DateTime.Now.Month;
            monthUntil = monthUntil ?? DateTime.Now.Month;
           
            DateTime sinceDate = new DateTime(Anio, monthSince.Value, DateTime.Now.Day); 
            DateTime untilDate = new DateTime(Anio, monthUntil.Value, DateTime.Now.Day); 


            return await _context.Sales.Where(x => x.DateSale >= sinceDate && x.DateSale <= untilDate && x.IdSupplier == IdSupp && x.IdProduct == IdProd).ToListAsync();
        }


        private bool SalesExists(int id)
        {
            return _context.Sales.Any(e => e.IdSale == id);
        }
    }
}
