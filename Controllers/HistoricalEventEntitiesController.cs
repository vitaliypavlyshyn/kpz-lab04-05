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
    public class HistoricalEventEntitiesController : ControllerBase
    {
        private readonly HistoricalEventDbContext _context;

        public HistoricalEventEntitiesController(HistoricalEventDbContext context)
        {
            _context = context;
        }

        // GET: api/HistoricalEventEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricalEventEntity>>> GetHistoricalEvents()
        {
          if (_context.HistoricalEvents == null)
          {
              return NotFound();
          }
            return await _context.HistoricalEvents.ToListAsync();
        }

        // GET: api/HistoricalEventEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricalEventEntity>> GetHistoricalEventEntity(int id)
        {
          if (_context.HistoricalEvents == null)
          {
              return NotFound();
          }
            var historicalEventEntity = await _context.HistoricalEvents.FindAsync(id);

            if (historicalEventEntity == null)
            {
                return NotFound();
            }

            return historicalEventEntity;
        }

        // PUT: api/HistoricalEventEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricalEventEntity(int id, HistoricalEventEntity historicalEventEntity)
        {
            if (id != historicalEventEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(historicalEventEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricalEventEntityExists(id))
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

        // POST: api/HistoricalEventEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoricalEventEntity>> PostHistoricalEventEntity(HistoricalEventEntity historicalEventEntity)
        {
          if (_context.HistoricalEvents == null)
          {
              return Problem("Entity set 'HistoricalEventDbContext.HistoricalEvents'  is null.");
          }
            _context.HistoricalEvents.Add(historicalEventEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoricalEventEntity", new { id = historicalEventEntity.Id }, historicalEventEntity);
        }

        // DELETE: api/HistoricalEventEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoricalEventEntity(int id)
        {
            if (_context.HistoricalEvents == null)
            {
                return NotFound();
            }
            var historicalEventEntity = await _context.HistoricalEvents.FindAsync(id);
            if (historicalEventEntity == null)
            {
                return NotFound();
            }

            _context.HistoricalEvents.Remove(historicalEventEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoricalEventEntityExists(int id)
        {
            return (_context.HistoricalEvents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
