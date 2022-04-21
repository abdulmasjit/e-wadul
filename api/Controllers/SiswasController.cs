#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ewadul.Api.Data;
using Ewadul.Api.Models;
namespace Ewadul.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiswasController : ControllerBase
    {
        private readonly DataContext _context;

        public SiswasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Siswas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Siswa>>> GetSiswas()
        {
            return await _context.Siswas.ToListAsync();
        }

        // GET: api/Siswas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Siswa>> GetSiswa(int id)
        {
            var siswa = await _context.Siswas.FindAsync(id);

            if (siswa == null)
            {
                return NotFound();
            }

            return siswa;
        }

        // PUT: api/Siswas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiswa(int id, Siswa siswa)
        {
            if (id != siswa.Id)
            {
                return BadRequest();
            }

            _context.Entry(siswa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiswaExists(id))
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

        // POST: api/Siswas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Siswa>> PostSiswa(Siswa siswa)
        {
            _context.Siswas.Add(siswa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSiswa", new { id = siswa.Id }, siswa);
        }

        // DELETE: api/Siswas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiswa(int id)
        {
            var siswa = await _context.Siswas.FindAsync(id);
            if (siswa == null)
            {
                return NotFound();
            }

            _context.Siswas.Remove(siswa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SiswaExists(int id)
        {
            return _context.Siswas.Any(e => e.Id == id);
        }
    }
}
