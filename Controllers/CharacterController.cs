using DnDManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace DnDManager.Controllers
{
    public class CharacterController : Controller
    {
        private readonly AppDbContext _context;

        public CharacterController(AppDbContext context)
        {
            _context = context;
        }

        // Actions go here
        
        // GET: api/character
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _context.Set<Character>().ToListAsync();
        }

        // GET: api/character/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _context.Set<Character>().FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // POST: api/character
        [HttpPost]
        public async Task<ActionResult<Character>> CreateCharacter(Character character)
        {
            _context.Set<Character>().Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCharacter),
                new { id = character.CharacterId },
                character
            );
        }

        // PUT: api/character/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, Character character)
        {
            if (id != character.CharacterId)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Set<Character>().Any(c => c.CharacterId == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/character/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Set<Character>().FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            _context.Set<Character>().Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
