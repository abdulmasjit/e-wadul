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
    [Route("api/v1/pengaduan")]
    [ApiController]
    public class PengaduanController : ControllerBase
    {
        private readonly DataContext _context;

        public PengaduanController(DataContext context)
        {
            _context = context;
        }

        // GET: api/v1/pengaduan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pengaduan>>> GetAll()
        {
            return await _context.Pengaduans.ToListAsync();
        }

        // GET: api/v1/pengaduan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pengaduan>> GetById(int id)
        {
            var pengaduan = await _context.Pengaduans.FindAsync(id);

            if (pengaduan == null)
            {
                return NotFound();
            }

            return pengaduan;
        }

        // POST: api/v1/pengaduan
        [HttpPost]
        public async Task<ActionResult<Pengaduan>> CreatePengaduan(RequestPengaduan req)
        {
            DateTime dt = Convert.ToDateTime(req.Tanggal);
            string  s2 = dt.ToString("yyyy-MM-dd");
            DateTime tglPengaduan = Convert.ToDateTime(s2);

            var pengaduan = new Pengaduan(){
                Tanggal = tglPengaduan,
                IdJenisPengaduan = req.IdJenisPengaduan,
                IdKecamatan = req.IdKecamatan,
                Longitude = req.Longitude,
                Latitude = req.Latitude,
                Alamat = req.Alamat,
                Keterangan = req.Keterangan,
                IdUser = req.IdUser,
                Status = "1" // PROSES
            };

            _context.Pengaduans.Add(pengaduan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = pengaduan.Id }, pengaduan);
        }

        // PUT: api/v1/pengaduan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePengaduan(int id,  RequestPengaduan req)
        {
            var pengaduan = await _context.Pengaduans.FindAsync(id);
            if (pengaduan == null)
            {
                return NotFound();
            }
            
            // Binding data
            DateTime dt = Convert.ToDateTime(req.Tanggal);
            string  s2 = dt.ToString("yyyy-MM-dd");
            DateTime tglPengaduan = Convert.ToDateTime(s2);

            pengaduan.Tanggal = tglPengaduan;
            pengaduan.IdJenisPengaduan = req.IdJenisPengaduan;
            pengaduan.IdKecamatan = req.IdKecamatan;
            pengaduan.Longitude = req.Longitude;
            pengaduan.Latitude = req.Latitude;
            pengaduan.Alamat = req.Alamat;
            pengaduan.Keterangan = req.Keterangan;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PengaduanExists(id))
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

        // DELETE: api/v1/pengaduan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePengaduan(int id)
        {
            var pengaduan = await _context.Pengaduans.FindAsync(id);
            if (pengaduan == null)
            {
                return NotFound();
            }

            _context.Pengaduans.Remove(pengaduan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PengaduanExists(int id)
        {
            return _context.Pengaduans.Any(e => e.Id == id);
        }
    }
}
