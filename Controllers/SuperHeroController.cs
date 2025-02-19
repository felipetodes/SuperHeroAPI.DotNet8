using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.DotNet8.Entities;

namespace SuperHeroAPI.DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id = 1,
                    Name = "Spiderman",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York"
                }
            };
            return Ok(heroes);
        }
    }
}
