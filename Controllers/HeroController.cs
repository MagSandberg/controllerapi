using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superhero_api.Models;

namespace Superhero_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private static List<Hero> _heroes = new List<Hero>()
        {
            new() { Id = 1, Name = "Tony Stark", Team = "Avengers", SuperHeroName = "Järnmannen" },
            new() { Id = 2, Name = "Bruce Wayne", Team = "Justice League", SuperHeroName = "Läderlappen" }
        };

        [HttpGet]
        public IActionResult GetHeros()
        {
            return Ok(_heroes);
        }

        [HttpGet("{id}")]
        public IActionResult GetHeroId(int id)
        {
            return Ok(_heroes.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult PostHero(Hero hero)
        {
            _heroes.Add(hero);
            return Ok(_heroes);
        }

        [HttpPut("{id}")]
        public IActionResult PutHero(Hero hero)
        {
            var heroToUpdate = _heroes.FirstOrDefault(x => x.Id == hero.Id);
            if (heroToUpdate == null)
            {
                return NotFound();
            }

            heroToUpdate.Name = hero.Name;
            heroToUpdate.Team = hero.Team;
            heroToUpdate.SuperHeroName = hero.SuperHeroName;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHero(int id)
        {
            var heroToDelete = _heroes.FirstOrDefault(x => x.Id == id);
            if (heroToDelete == null)
            {
                return NotFound();
            }

            _heroes.Remove(heroToDelete);
            return Ok();
        }
    }
}
