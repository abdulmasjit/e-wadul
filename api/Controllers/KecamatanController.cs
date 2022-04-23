using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ewadul.Api.Data;
using Ewadul.Api.Models;
using Ewadul.Api.DTO;
namespace Ewadul.Api.Controllers
{
    // Setting nama route
    [Route("api/v1/kecamatan")]
    [ApiController]
    public class KecamatanController : ControllerBase
    {
        private readonly DataContext _context;

        public KecamatanController(DataContext context)
        {
            _context = context;
        }

        // GET: api/v1/kecamatan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kecamatan>>> GetAll()
        {
            return await _context.Kecamatans.ToListAsync();
        }

        // GET: api/v1/kecamatan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kecamatan>> GetById(string id)
        {
            var kecamatan = await _context.Kecamatans.FindAsync(id);

            if (kecamatan == null)
            {
                return NotFound();
            }

            return kecamatan;
        }

        // POST: api/v1/kecamatan
        [HttpPost]
        public async Task<ActionResult<KecamatanDTO>> CreateKecamatan(KecamatanDTO req)
        {
            var kecamatan = new Kecamatan(){
                Id = req.Id,
                Nama = req.Nama,
                RegencyId = req.RegencyId
            };

            _context.Kecamatans.Add(kecamatan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = kecamatan.Id }, kecamatan);
        }

        // PUT: api/v1/kecamatan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKecamatan(string id,  KecamatanDTO req)
        {
            var kecamatan = await _context.Kecamatans.FindAsync(id);
            if (kecamatan == null)
            {
                return NotFound();
            }
            
            // Binding data
            kecamatan.Nama = req.Nama;
            kecamatan.RegencyId = req.RegencyId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KecamatanExists(id))
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

        // DELETE: api/v1/kecamatan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKecamatan(string id)
        {
            var kecamatan = await _context.Kecamatans.FindAsync(id);
            if (kecamatan == null)
            {
                return NotFound();
            }

            _context.Kecamatans.Remove(kecamatan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KecamatanExists(string id)
        {
            return _context.Kecamatans.Any(e => e.Id == id);
        }
    }
}
