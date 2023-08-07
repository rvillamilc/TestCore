using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWebTest.Context;
using ApiWebTest.Model;

namespace ApiWebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanosController : ControllerBase
    {
        private readonly DataContext _context;

        public HumanosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Humanos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Humano>>> GetHumano()
        {
            return await _context.Humano.ToListAsync();
        }


        // GET: api/Humanos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Humano>> GetHumano(long id)
        {
            var humano = await _context.Humano.FindAsync(id);

            if (humano == null)
            {
                return NotFound();
            }

            return humano;
        }

        [HttpGet]
        [Route("GetHumanoList")]
        public List<Humano> GetHumanoList()
        {
            List<Humano> humans = new List<Humano> {
                new Humano()  {Id=1, Nombre="Test1" , Sexo="H", Edad=35, Altura=1.77M, Peso=75},
                new Humano() {Id=2, Nombre="Test2" , Sexo="F", Edad=25, Altura=1.65M, Peso=62},
                new Humano() {Id=3, Nombre="Test3" , Sexo="F", Edad=25, Altura=1.55M, Peso=55},
                new Humano() {Id=4, Nombre="Test4" , Sexo="H", Edad=41, Altura=1.82M, Peso=95}

            };
            return humans.ToList();
        }


        // PUT: api/Humanos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHumano(long id, Humano humano)
        {
            if (id != humano.Id)
            {
                return BadRequest();
            }

            _context.Entry(humano).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HumanoExists(id))
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

        // POST: api/Humanos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Humano>> PostHumano(Humano humano)
        {
            _context.Humano.Add(humano);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHumano", new { id = humano.Id }, humano);
        }



        // DELETE: api/Humanos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHumano(long id)
        {
            var humano = await _context.Humano.FindAsync(id);
            if (humano == null)
            {
                return NotFound();
            }

            _context.Humano.Remove(humano);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HumanoExists(long id)
        {
            return _context.Humano.Any(e => e.Id == id);
        }
    }
}
