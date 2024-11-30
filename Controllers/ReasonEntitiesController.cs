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
    public class ReasonEntitiesController : ControllerBase
    {
        private readonly HistoricalEventDbContext _context;

        public ReasonEntitiesController(HistoricalEventDbContext context)
        {
            _context = context;
        }

        // GET: api/ReasonEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReasonEntity>>> GetReasons()
        {
          if (_context.Reasons == null)
          {
              return NotFound();
          }
            return await _context.Reasons.ToListAsync();
        }

        // GET: api/ReasonEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReasonEntity>> GetReasonEntity(int id)
        {
          if (_context.Reasons == null)
          {
              return NotFound();
          }
            var reasonEntity = await _context.Reasons.FindAsync(id);

            if (reasonEntity == null)
            {
                return NotFound();
            }

            return reasonEntity;
        }

        // PUT: api/ReasonEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReasonEntity(int id, ReasonEntity reasonEntity)
        {
            if (id != reasonEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(reasonEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReasonEntityExists(id))
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

        // POST: api/ReasonEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReasonEntity>> PostReasonEntity(ReasonEntity reasonEntity)
        {
          if (_context.Reasons == null)
          {
              return Problem("Entity set 'HistoricalEventDbContext.Reasons'  is null.");
          }
            _context.Reasons.Add(reasonEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReasonEntity", new { id = reasonEntity.Id }, reasonEntity);
        }

        // DELETE: api/ReasonEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReasonEntity(int id)
        {
            if (_context.Reasons == null)
            {
                return NotFound();
            }
            var reasonEntity = await _context.Reasons.FindAsync(id);
            if (reasonEntity == null)
            {
                return NotFound();
            }

            _context.Reasons.Remove(reasonEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReasonEntityExists(int id)
        {
            return (_context.Reasons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
