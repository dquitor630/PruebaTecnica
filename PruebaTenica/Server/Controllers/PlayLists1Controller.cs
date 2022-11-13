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
    public class PlayLists1Controller : ControllerBase
    {
        private readonly FilmDbContext _context;

        public PlayLists1Controller(FilmDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayLists1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayList>>> GetPlayList()
        {
            return await _context.PlayList.ToListAsync();
        }

        // GET: api/PlayLists1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayList>> GetPlayList(int id)
        {
            var playList = await _context.PlayList.FindAsync(id);

            if (playList == null)
            {
                return NotFound();
            }

            return playList;
        }

        // PUT: api/PlayLists1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayList(int id, PlayList playList)
        {
            if (id != playList.Id)
            {
                return BadRequest();
            }

            _context.Entry(playList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayListExists(id))
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

        // POST: api/PlayLists1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayList>> PostPlayList(PlayList playList)
        {
            _context.PlayList.Add(playList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayList", new { id = playList.Id }, playList);
        }

        // DELETE: api/PlayLists1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayList(int id)
        {
            var playList = await _context.PlayList.FindAsync(id);
            if (playList == null)
            {
                return NotFound();
            }

            _context.PlayList.Remove(playList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayListExists(int id)
        {
            return _context.PlayList.Any(e => e.Id == id);
        }
    }
}
