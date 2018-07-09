using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEST.API.Analytics.API;
using TEST.API.Analytics.API.DO;

namespace TEST.API.Analytics.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        private readonly Model _context;

        public CoursesController(Model context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public IEnumerable<CourseDO> GetCourses()
        {
            return _context.Courses;
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseDO([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseDO = await _context.Courses.SingleOrDefaultAsync(m => m.ID == id);

            if (courseDO == null)
            {
                return NotFound();
            }

            return Ok(courseDO);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseDO([FromRoute] int id, [FromBody] CourseDO courseDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseDO.ID)
            {
                return BadRequest();
            }

            _context.Entry(courseDO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseDOExists(id))
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

        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> PostCourseDO([FromBody] CourseDO courseDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Courses.Add(courseDO);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseDOExists(courseDO.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourseDO", new { id = courseDO.ID }, courseDO);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseDO([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseDO = await _context.Courses.SingleOrDefaultAsync(m => m.ID == id);
            if (courseDO == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(courseDO);
            await _context.SaveChangesAsync();

            return Ok(courseDO);
        }

        private bool CourseDOExists(int id)
        {
            return _context.Courses.Any(e => e.ID == id);
        }
    }
}