using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityContext;
using Model;

namespace LiveSessionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveSessionsController : ControllerBase
    {
        private readonly SFeedbackDbContext _context;

        public LiveSessionsController(SFeedbackDbContext context)
        {
            _context = context;
        }

        // GET: api/LiveSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LiveSession>>> GetliveSessions()
        {
            _context.Database.EnsureCreated();
            if (!_context.liveSessions.Any())
            {
                _context.liveSessions.Add(new LiveSession()
                {
                     isPrivate = true,
                      organiser = "Mike Zed",
                       Url = "nO Url",
                        duration = 60,
                         description = "Session on .net ",
                          sessionCategory = ".Net",
                           sessionFeedbacks = new List<SessionFeedback> ()
                           {
                               new SessionFeedback()
                               {
                                    rating = 10
                               }
                           }

                });
            }
            var proxydata = _context.liveSessions.Count();

            //Gives the count of data in the local or in memory. Initiallly its 0 when no data in db
            var localData = _context.liveSessions.Local.Count();

            // Here the changes will be saved
            _context.SaveChanges();
            return await _context.liveSessions.ToListAsync();
        }

        // GET: api/LiveSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LiveSession>> GetLiveSession(int id)
        {
            var liveSession = await _context.liveSessions.FindAsync(id);

            if (liveSession == null)
            {
                return NotFound();
            }

            return liveSession;
        }

        // PUT: api/LiveSessions/5
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
