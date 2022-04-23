namespace Ewadul.Api.DTO;
using Ewadul.Api.Models;
public class AuthenticateResponse
{
    public int Id { get; set; }
    public string? Nama { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Token { get; set; }

    public AuthenticateResponse(User user, string token)
    {
        Id = user.Id;
        Nama = user.Nama;
        Username = user.Username;
        Email = user.Email;
        Token = token;
    }
}