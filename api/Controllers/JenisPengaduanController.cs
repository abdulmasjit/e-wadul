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
        public async Task<ActionResult<JenisPengaduan>> PostJenisPengaduan(RequestJenisPengaduan req)
        {
            var jenisPengaduan = new JenisPengaduan(){
                Nama = req.Nama,
                Status = 1 // active
            };

            _context.JenisPengaduan.Add(jenisPengaduan);
            await _context.SaveChangesAsync();

            return jenisPengaduan;
            // return CreatedAtAction("GetJenisPengaduan", new { id = jenisPengaduan.Id }, jenisPengaduan);
        }

        // PUT: api/Siswas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutSiswa(int id, Siswa siswa)
        // {
        //     if (id != siswa.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(siswa).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!SiswaExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // DELETE: api/Siswas/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteSiswa(int id)
        // {
        //     var siswa = await _context.Siswas.FindAsync(id);
        //     if (siswa == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Siswas.Remove(siswa);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool SiswaExists(int id)
        // {
        //     return _context.Siswas.Any(e => e.Id == id);
        // }
    }
}
