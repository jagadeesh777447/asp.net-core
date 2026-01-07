using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Web_APP.DBContext;
using My_Web_APP.Models; // 👈 instead of DBContext namespace

public class UsersController : Controller
{
    private readonly CiCdContext _context;

    public UsersController(CiCdContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _context.Users.ToListAsync();

        // Map DBContext.User → Models.User
        var model = users.Select(u => new My_Web_APP.Models.User
        {
            Id = u.Id,
            Name = u.Name
        }).ToList();

        return View(model);
    }
}
