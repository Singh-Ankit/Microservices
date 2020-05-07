using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityContext;
using Model;

namespace CatalogueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CataloguesController : ControllerBase
    {
        private readonly ServiceDbContext _context;

        public CataloguesController(ServiceDbContext context)
        {
            _context = context;
        }

        // GET: api/Catalogues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalogue>>> Getcatalogues()
        {
            _context.Database.EnsureCreated();
            if (!_context.catalogues.Any())
            {
                _context.catalogues.Add(new Catalogue() 
                {
                     catalogueName = ".NET Core",
                      catalogueType = "Training",
                       description = "Level: Begonner",
                         rating = 4.2f
                });

                //Gives the count of data which in the db not in memory.
                var proxydata = _context.catalogues.Count();

                //Gives the count of data in the local or in memory. Initiallly its 0 when no data in db
                var localData = _context.catalogues.Local.Count();

                // Here the changes will be saved
                _context.SaveChanges();
            }
            return await _context.catalogues.ToListAsync();
        }

        //// GET: api/Catalogues/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Catalogue>> GetCatalogue(int id)
        //{
        //    var catalogue = await _context.catalogues.FindAsync(id);

        //    if (catalogue == null)
        //    {
        //        return NotFound();
        //    }

        //    return catalogue;
        //}

        //// PUT: api/Catalogues/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCatalogue(int id, Catalogue catalogue)
        //{
        //    if (id != catalogue.catalogueID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(catalogue).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CatalogueExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Catalogues
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Catalogue>> PostCatalogue(Catalogue catalogue)
        //{
        //    _context.catalogues.Add(catalogue);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCatalogue", new { id = catalogue.catalogueID }, catalogue);
        //}

        //// DELETE: api/Catalogues/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Catalogue>> DeleteCatalogue(int id)
        //{
        //    var catalogue = await _context.catalogues.FindAsync(id);
        //    if (catalogue == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.catalogues.Remove(catalogue);
        //    await _context.SaveChangesAsync();

        //    return catalogue;
        //}

        //private bool CatalogueExists(int id)
        //{
        //    return _context.catalogues.Any(e => e.catalogueID == id);
        //}
    }
}
