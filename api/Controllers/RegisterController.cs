
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ewadul.Api.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;

        public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/v1/Register
        public async Task<Object> PostUser(User model)
        {
            var User = new User() {

                Id = model.Id,
                Nama = model.Nama,
                Username = model.Username,
                Email = model.Email,
                Nik = model.Nik,
                Telepon = model.Telepon,
                Alamat = model.Alamat,
                Status = model.Status,
                IdRole = model.IdRole,
                Password = model.Password

            };

            try
            {
                var result = await _userManager.CreateAsync(User, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}