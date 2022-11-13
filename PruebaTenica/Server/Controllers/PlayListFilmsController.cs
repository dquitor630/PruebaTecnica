using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTenica.Server.Db;
using PruebaTenica.Shared;

namespace PruebaTenica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListFilmsController : ControllerBase
    {
        private readonly FilmDbContext _context;

        public PlayListFilmsController(FilmDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayListFilms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayListFilms>>> GetPlayListFilms()
        {
            return await _context.PlayListFilms.ToListAsync();
        }

        // GET: api/PlayListFilms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayListFilms>> GetPlayListFilms(int id)
        {
            var playListFilms = await _context.PlayListFilms.FindAsync(id);

            if (playListFilms == null)
            {
                return NotFound();
            }

            return playListFilms;
        }

        // PUT: api/PlayListFilms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayListFilms(int id, PlayListFilms playListFilms)
        {
            if (id != playListFilms.Id)
            {
                return BadRequest();
            }

            _context.Entry(playListFilms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayListFilmsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlayListFilms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayListFilms>> PostPlayListFilms(PlayListFilms playListFilms)
        {
            _context.PlayListFilms.Add(playListFilms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayListFilms", new { id = playListFilms.Id }, playListFilms);
        }

        // DELETE: api/PlayListFilms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayListFilms(int id)
        {
            var playListFilms = await _context.PlayListFilms.FindAsync(id);
            if (playListFilms == null)
            {
                return NotFound();
            }

            _context.PlayListFilms.Remove(playListFilms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayListFilmsExists(int id)
        {
            return _context.PlayListFilms.Any(e => e.Id == id);
        }
    }
}
