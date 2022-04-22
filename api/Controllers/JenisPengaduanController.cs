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
using Ewadul.Api.DTO;
namespace Ewadul.Api.Controllers
{
    // Setting nama route
    [Route("api/v1/jenis-pengaduan")]
    [ApiController]
    public class JenisPengaduanController : ControllerBase
    {
        private readonly DataContext _context;

        public JenisPengaduanController(DataContext context)
        {
            _context = context;
        }

        // GET: api/v1/jenis-pengaduan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JenisPengaduan>>> GetAll()
        {
            return await _context.JenisPengaduan.ToListAsync();
        }

        // GET: api/v1/jenis-pengaduan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JenisPengaduan>> GetById(int id)
        {
            var jenisPengaduan = await _context.JenisPengaduan.FindAsync(id);

            if (jenisPengaduan == null)
            {
                return NotFound();
            }

            return jenisPengaduan;
        }

        // POST: api/v1/jenis-pengaduan
        [HttpPost]
        public async Task<ActionResult<JenisPengaduan>> CreateJenisPengaduan(RequestJenisPengaduan req)
        {
            var jenisPengaduan = new JenisPengaduan(){
                Nama = req.Nama,
                Status = 1 // active
            };

            _context.JenisPengaduan.Add(jenisPengaduan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = jenisPengaduan.Id }, jenisPengaduan);
        }

        // PUT: api/v1/jenis-pengaduan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJenisPengaduan(int id,  RequestJenisPengaduan req)
        {
            var jenisPengaduan = await _context.JenisPengaduan.FindAsync(id);
            if (jenisPengaduan == null)
            {
                return NotFound();
            }
            
            // Binding data
            jenisPengaduan.Nama = req.Nama;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JenisPengaduanExists(id))
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

        // DELETE: api/v1/jenis-pengaduan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJenisPengaduan(int id)
        {
            var jenisPengaduan = await _context.JenisPengaduan.FindAsync(id);
            if (jenisPengaduan == null)
            {
                return NotFound();
            }

            _context.JenisPengaduan.Remove(jenisPengaduan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JenisPengaduanExists(int id)
        {
            return _context.JenisPengaduan.Any(e => e.Id == id);
        }
    }
}
