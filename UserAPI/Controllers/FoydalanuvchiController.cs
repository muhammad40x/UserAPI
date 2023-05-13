using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Context;
using UserAPI.Entites;
using UserAPI.Model;

namespace UserAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
//[EnableCors]
public class FoydalanuvchiController : ControllerBase
{

    private AppDbContext _context;

    public FoydalanuvchiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Foydalanuvchi>> GetList()
    {
        var users = await _context.Foydalanuvchi
            .Where(c=>c.Ismi!=null)
            .ToListAsync();

        return users;
    }

    [HttpPost]
    public async Task<IActionResult> EnterName([FromBody]FoydalanuvchiDto foydalanuvchiDto)
    {
        var foydalanuvchi = new Foydalanuvchi()
        {
            Ismi = foydalanuvchiDto.Ismi,
            Parol = foydalanuvchiDto.Parol
        };

        _context.Foydalanuvchi.Add(foydalanuvchi);
        await _context.SaveChangesAsync();


        return Ok(foydalanuvchi);
    }
}
