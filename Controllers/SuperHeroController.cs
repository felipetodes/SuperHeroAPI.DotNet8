using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.DotNet8.Data;
using SuperHeroAPI.DotNet8.Entities;

namespace SuperHeroAPI.DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext? _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }
    }
}
