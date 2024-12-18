using System;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly TokenService _tokenService;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly BookContext _context;
    public AuthController(UserManager<IdentityUser> userManager, TokenService tokenService, SignInManager<IdentityUser> signInManager, BookContext context)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return Unauthorized(new { Message = "Invalid email or password" });
        }

        var token = await _tokenService.GenerateTokenAsync(user);

        Console.WriteLine(token);

        Response.Cookies.Append("jwt", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true, 
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(30)
        });

        return Ok(new { Message = "Registration successful" });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if (registerDto.Password != registerDto.ConfirmPassword)
        {
            return BadRequest(new { Message = "Passwords do not match" });
        }

        var user = new IdentityUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Email
        };

  
        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new { Message = string.Join(", ", result.Errors.Select(e => e.Description)) });
        }

        var appUser = new User
        {
            Fullname = registerDto.Username,
            Email = registerDto.Email,
            Password = registerDto.Password,
            Phone = "0000000000000",
            Address = "Binh Duong",
            Status = 1,
            Description = "new user",
            CreatedDate = DateTime.UtcNow,
            UserCode = Guid.NewGuid().ToString(),
            IsLocked = false,
            IsDeleted = false,
            IsActive = true,
            ActiveCode = Guid.NewGuid().ToString(),
            Avatar = "",
            Loans = new List<Loan>()
        };
        _context.Add(appUser);
        await _context.SaveChangesAsync();

        await _userManager.AddToRoleAsync(user, "User");

        await _signInManager.SignInAsync(user, isPersistent: false);

        return Ok(new { Message = "Registration successful" });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
    
        Response.Cookies.Append("jwt", "", new CookieOptions
        {
            Expires = DateTime.UtcNow.AddDays(-1),
            HttpOnly = true,  
            Secure = true,
            SameSite = SameSiteMode.Strict 
        });

        await _signInManager.SignOutAsync();

        return Ok(new { message = "Logged out successfully" });
    }

}



public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
public class RegisterDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

