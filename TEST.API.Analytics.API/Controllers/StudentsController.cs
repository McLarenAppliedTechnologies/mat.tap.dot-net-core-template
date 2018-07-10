using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEST.API.Analytics.API;
using TEST.API.Analytics.API.DO;
using TEST.API.Core.DataManagers;
using TEST.API.Core.Factories;

namespace TEST.API.Analytics.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentsController : Controller
    {
        private readonly IDataManager<StudentDO, int> dataManager;
        private readonly DbContext dbContext;

        public StudentsController(IDataManager<StudentDO, int> dataManager, IDbContextFactory dbContextFactory)
        {
            this.dataManager = dataManager;
            dbContext = dbContextFactory.CreateNewDbContext();
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var studentDOs = await dataManager.GetAllItemsQuery(dbContext).ToListAsync();
            return Ok(studentDOs);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            try
            {
                var studentDO = await dataManager.GetItemById(dbContext, id);
                return Ok(studentDO);
            }
            catch (EntityNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent([FromRoute] int id, [FromBody] StudentDO studentDO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != studentDO.Id) return BadRequest();

            try
            {
                await dataManager.UpdateEntity(dbContext, studentDO);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] StudentDO studentDO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await dataManager.AddEntity(dbContext, studentDO);
                return Created("", studentDO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            try
            {
                await dataManager.DeleteEntity(dbContext, id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}