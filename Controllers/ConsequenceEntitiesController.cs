using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QQQQ;

namespace QQQQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ConsequenceEntitiesController : ControllerBase
    {
        private readonly HistoricalEventDbContext _context;

        public ConsequenceEntitiesController(HistoricalEventDbContext context)
        {
            _context = context;
        }

        // GET: api/ConsequenceEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsequenceEntity>>> GetConsequences()
        {
          if (_context.Consequences == null)
          {
              return NotFound();
          }
            return await _context.Consequences.ToListAsync();
        }

        // GET: api/ConsequenceEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsequenceEntity>> GetConsequenceEntity(int id)
        {
          if (_context.Consequences == null)
          {
              return NotFound();
          }
            var consequenceEntity = await _context.Consequences.FindAsync(id);

            if (consequenceEntity == null)
            {
                return NotFound();
            }

            return consequenceEntity;
        }

        // PUT: api/ConsequenceEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsequenceEntity(int id, ConsequenceEntity consequenceEntity)
        {
            if (id != consequenceEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(consequenceEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsequenceEntityExists(id))
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

        // POST: api/ConsequenceEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsequenceEntity>> PostConsequenceEntity(ConsequenceEntity consequenceEntity)
        {
          if (_context.Consequences == null)
          {
              return Problem("Entity set 'HistoricalEventDbContext.Consequences'  is null.");
          }
            _context.Consequences.Add(consequenceEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsequenceEntity", new { id = consequenceEntity.Id }, consequenceEntity);
        }

        // DELETE: api/ConsequenceEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsequenceEntity(int id)
        {
            if (_context.Consequences == null)
            {
                return NotFound();
            }
            var consequenceEntity = await _context.Consequences.FindAsync(id);
            if (consequenceEntity == null)
            {
                return NotFound();
            }

            _context.Consequences.Remove(consequenceEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsequenceEntityExists(int id)
        {
            return (_context.Consequences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
