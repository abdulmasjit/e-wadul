#nullable disable

using Microsoft.AspNetCore.Mvc;
using Ewadul.Api.Data;
using Ewadul.Api.Models;
using Ewadul.Api.DTO;
using Ewadul.Api.Helpers;

namespace Ewadul.Api.Controllers
{
    // Setting nama route
    [Route("api/v1/Register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly DataContext _context;

        public RegisterController(DataContext context)
        {
            _context = context;
        }

        // POST: api/v1/regis
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(RequestRegister req)
        {
            string md5StringPassword = AppHelper.GetMd5Hash(req.Password);
            var user = new User()
            {
                Nama = req.Nama,
                Username = req.Username,
                Email = req.Email,
                Alamat = req.Alamat,
                Nik = req.Nik,
                Telepon = req.Telepon,
                Password = md5StringPassword,
                IdRole = "MASYARAKAT",
                Status = 1 // Active
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}

