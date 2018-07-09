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
    [Route("api/Student")]
    public class StudentsController : Controller
    {
        private readonly Model _context;

        public StudentsController(Model context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public IEnumerable<StudentDO> GetStudents()
        {
            return _context.Students;
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentDO([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentDO = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);

            if (studentDO == null)
            {
                return NotFound();
            }

            return Ok(studentDO);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentDO([FromRoute] int id, [FromBody] StudentDO studentDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentDO.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentDO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDOExists(id))
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

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> PostStudentDO([FromBody] StudentDO studentDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Students.Add(studentDO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentDO", new { id = studentDO.Id }, studentDO);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentDO([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentDO = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);
            if (studentDO == null)
            {
                return NotFound();
            }

            _context.Students.Remove(studentDO);
            await _context.SaveChangesAsync();

            return Ok(studentDO);
        }

        private bool StudentDOExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}