using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityContext;
using Model;
using LiveSessionAPI.Repository;
using Newtonsoft.Json;

namespace LiveSessionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveSessionsAPIController : ControllerBase
    {
        private readonly SFeedbackDbContext _context;
        LiveSessionRepo repo = new LiveSessionRepo();

        public LiveSessionsAPIController(SFeedbackDbContext context)
        {
            _context = context;
        }

        // GET: api/LiveSessionsAPI/5
        //[HttpGet("{category}")]
        [HttpGet("{category}", Name = "GetLiveSession")]
        // public async Task<ActionResult<LiveSession>> GetLiveSession(int id)
        public async Task<ActionResult<IEnumerable<LiveSession>>> GetLiveSession([FromRoute] String category)
        {
          

            //IList<SessionFeedback> _sessionFeedbacks = await _context.sessionFeedbacks
            //                                           .Include(l => l.liveSession)
            //                                           .Where(x => x.liveSession.sessionCategory == category)
            //                                           .ToListAsync();
            //IList<LiveSession> _liveSessions = await _context.liveSessions
            //                                    .Include(f => f.sessionFeedbacks)
            //                                    .Where(x => x.sessionCategory == category)
            //                                    .ToListAsync();
            IList<LiveSession> result = await _context.liveSessions.Where(x => x.sessionCategory == category).ToListAsync();



            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return await _context.liveSessions.Where(x => x.sessionCategory == category).ToListAsync();
            }

            
        }

        // PUT: api/LiveSessionsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiveSession(int id, LiveSession liveSession)
        {
            if (id != liveSession.SId)
            {
                return BadRequest();
            }

            _context.Entry(liveSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiveSessionExists(id))
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

        // POST: api/LiveSessions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LiveSession>> PostLiveSession(LiveSession liveSession)
        {
            _context.liveSessions.Add(liveSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLiveSession", new { id = liveSession.SId }, liveSession);
        }

        // DELETE: api/LiveSessions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LiveSession>> DeleteLiveSession(int id)
        {
            var liveSession = await _context.liveSessions.FindAsync(id);
            if (liveSession == null)
            {
                return NotFound();
            }

            _context.liveSessions.Remove(liveSession);
            await _context.SaveChangesAsync();

            return liveSession;
        }

        private bool LiveSessionExists(int id)
        {
            return _context.liveSessions.Any(e => e.SId == id);
        }
    }
}
