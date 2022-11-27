using IndOMTech.Client.Pages;
using IndOMTech.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using SQLitePCL;

namespace IndOMTech.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    private readonly ILogger<ContactUsController> _logger;
    private readonly DBContext _dbcontext;
    //private List<ContactUs> _contactUs = new List<ContactUs>();
    public UsersController(ILogger<ContactUsController> logger, DBContext dbcontext)
    {
        _logger = logger;
        _dbcontext = dbcontext;
    }
    [HttpGet]
    public async Task<List<Users>> GetUsers()
    {
        //await Task.Delay(1);
        return await _dbcontext.Users.ToListAsync();
    }

    [HttpGet("user/{userId}")]
    public async Task<Users> GetUserbyId(int userId)
    {
        //await Task.Delay(1);
        return await _dbcontext.Users?.FirstOrDefaultAsync(u => u.UserID == userId);
    }

    [HttpPost]
    //public async Task<IActionResult> AddUser([FromBody]  Users   user)
    public async Task<Users> AddUser([FromBody] Users user)
    {
        //await Task.Delay(1);
        if (!ModelState.IsValid)
            throw new Exception("Invalid data.");

        await _dbcontext.Users.AddAsync(user);
        await _dbcontext.SaveChangesAsync();
        //return user;
        return await Task.FromResult(user);
    }

    [HttpDelete("user/{userId}")]
    public async Task DeleteUsers(int userId)
    {
        var u = await _dbcontext.Users.FirstOrDefaultAsync(x => x.UserID == userId);
        if (u != null)
        {
            _dbcontext.Users.Remove(u);
           await _dbcontext.SaveChangesAsync(true);
        }
    }

    [HttpPut("user/{userId}")]
    public async Task<Users> UpdateContactUs(int userId, [FromBody] Users user)
    {
        if (!ModelState.IsValid)
            throw new Exception("Invalid data.");

        var u = await _dbcontext.Users.FirstOrDefaultAsync(u => u.UserID == userId);

        u.Name = user.Name;
        u.LastName = user.LastName;
        await _dbcontext.SaveChangesAsync();

        return await Task.FromResult(u);
    }
}
