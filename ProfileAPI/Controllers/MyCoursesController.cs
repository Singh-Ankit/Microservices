using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityContext;
using Model;

namespace ProfileAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MyCoursesController : ControllerBase
    {
        private readonly ProfileDbContext _context;

        public MyCoursesController(ProfileDbContext context)
        {
            _context = context;
        }

        // GET: api/MyCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyCourses>>> Getcatalogues()
        {
            _context.Database.EnsureCreated();
            return await _context.myCourses.ToListAsync();
        }

        // GET: api/MyCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyCourses>> GetMyCourses(int id)
        {
            _context.Database.EnsureCreated();
            var myCourses = await _context.myCourses.FindAsync(id);

            if (myCourses == null)
            {
                return NotFound();
            }

            return myCourses;
        }

        // PUT: api/MyCourses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyCourses(int id, MyCourses myCourses)
        {
            if (id != myCourses.itemID)
            {
                return BadRequest();
            }

            _context.Entry(myCourses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyCoursesExists(id))
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

        // POST: api/MyCourses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MyCourses>> PostMyCourses(MyCourses myCourses)
        {
            _context.Database.EnsureCreated();
            _context.myCourses.Add(myCourses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyCourses", new { id = myCourses.itemID }, myCourses);
        }

        // DELETE: api/MyCourses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MyCourses>> DeleteMyCourses(int id)
        {
            var myCourses = await _context.myCourses.FindAsync(id);
            if (myCourses == null)
            {
                return NotFound();
            }

            _context.myCourses.Remove(myCourses);
            await _context.SaveChangesAsync();

            return myCourses;
        }

        private bool MyCoursesExists(int id)
        {
            return _context.myCourses.Any(e => e.itemID == id);
        }
    }
}
