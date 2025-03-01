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
        private readonly DataContext _context;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound("Hero not found!");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody] SuperHero hero)
        {
            // Remova a definição explícita do valor da coluna de identidade
            _context.SuperHeroes.Add(new SuperHero
            {
                Name = hero.Name,
                FirstName = hero.FirstName,
                LastName = hero.LastName,
                Place = hero.Place
            });

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>>UpdateHero(SuperHero hero)

        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}