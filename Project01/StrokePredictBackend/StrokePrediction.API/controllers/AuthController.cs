using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrokePrediction.Infrastructure.database;
using System.ComponentModel.DataAnnotations;
using BCrypt.Net;

namespace StrokePrediction.API.controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;

    public AuthController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req)
    {
        var user = await _db.Users.SingleOrDefaultAsync(u => u.Username == req.Username);
        if (user == null || !user.IsActive)
            return Unauthorized(new { message = "Tài khoản không tồn tại hoặc bị khóa." });

        bool isValid = false;
        if (user.PasswordHash == "$2b$10$CHANGE_THIS_HASH_IN_PRODUCTION" && req.Password == "admin")
        {
            isValid = true; // Fallback cho DB mẫu chưa đổi pass
        }
        else
        {
            try { isValid = BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash); }
            catch { isValid = req.Password == user.PasswordHash; } // Fallback plain text nếu lỡ lưu plain text
        }

        if (!isValid) return Unauthorized(new { message = "Sai mật khẩu." });

        // Update last login
        user.LastLoginAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        return Ok(new
        {
            user.Id,
            user.Username,
            user.FullName,
            user.Role,
            Token = "dummy-jwt-token-for-winforms" // Nếu cần JWT thì có thể sinh ở đây
        });
    }
}

public class LoginRequest
{
    [Required] public string Username { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}
