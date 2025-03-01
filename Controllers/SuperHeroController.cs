﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
    
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var heroe = await _context.SuperHeroes.FindAsync(id);
            if(heroe == null)
            {
                return NotFound("Hero not found!");
            }
            return Ok(heroe);
        }
        [HttpGet]

        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var heroe = await _context.SuperHeroes.FindAsync(hero);
            if (heroe == null)
            {
                return NotFound("Hero not found!");
            }
            return Ok(heroe);
        }
    }
}
