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
    [Route("api/Enrollments")]
    public class EnrollmentsController : Controller
    {
        private readonly Model _context;

        public EnrollmentsController(Model context)
        {
            _context = context;
        }

        // GET: api/Enrollments
        [HttpGet]
        public IEnumerable<EnrollmentDO> GetEnrollments()
        {
            return _context.Enrollments;
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentDO([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollmentDO = await _context.Enrollments.SingleOrDefaultAsync(m => m.Id == id);

            if (enrollmentDO == null)
            {
                return NotFound();
            }

            return Ok(enrollmentDO);
        }

        // PUT: api/Enrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollmentDO([FromRoute] int id, [FromBody] EnrollmentDO enrollmentDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enrollmentDO.Id)
            {
                return BadRequest();
            }

            _context.Entry(enrollmentDO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentDOExists(id))
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

        // POST: api/Enrollments
        [HttpPost]
        public async Task<IActionResult> PostEnrollmentDO([FromBody] EnrollmentDO enrollmentDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Enrollments.Add(enrollmentDO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnrollmentDO", new { id = enrollmentDO.Id }, enrollmentDO);
        }

        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollmentDO([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollmentDO = await _context.Enrollments.SingleOrDefaultAsync(m => m.Id == id);
            if (enrollmentDO == null)
            {
                return NotFound();
            }

            _context.Enrollments.Remove(enrollmentDO);
            await _context.SaveChangesAsync();

            return Ok(enrollmentDO);
        }

        private bool EnrollmentDOExists(int id)
        {
            return _context.Enrollments.Any(e => e.Id == id);
        }
    }
}