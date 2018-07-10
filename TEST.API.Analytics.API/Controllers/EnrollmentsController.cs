using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEST.API.Analytics.API.DO;
using TEST.API.Analytics.API.DTO;
using TEST.API.Core.DataManagers;
using TEST.API.Core.Factories;

namespace TEST.API.Analytics.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Enrollments")]
    public class EnrollmentsController : Controller
    {
        private readonly IDataManager<EnrollmentDO, int> dataManager;
        private readonly DbContext dbContext;
        private readonly IMapper mapper;

        public EnrollmentsController(IDataManager<EnrollmentDO, int> dataManager, IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dataManager = dataManager;
            dbContext = dbContextFactory.CreateNewDbContext();
            this.mapper = mapper;
        }

        // GET: api/Enrollments
        [HttpGet]
        public async Task<IActionResult> GetEnrollments()
        {
            var enrollmentDOs = await dataManager.GetAllItemsQuery(dbContext).ToListAsync();
            var dtos = mapper.Map<IList<EnrollmentDTO>>(enrollmentDOs);
            return Ok(dtos);
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollment([FromRoute] int id)
        {
            try
            {
                var enrollmentDO = await dataManager.GetItemById(dbContext, id);
                var dto = mapper.Map<EnrollmentDTO>(enrollmentDO);
                return Ok(dto);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Enrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollment([FromRoute] int id, [FromBody] EnrollmentDO enrollmentDO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != enrollmentDO.Id) return BadRequest();

            try
            {
                await dataManager.UpdateEntity(dbContext, enrollmentDO);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Enrollments
        [HttpPost]
        public async Task<IActionResult> PostEnrollment([FromBody] EnrollmentDO enrollmentDO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await dataManager.AddEntity(dbContext, enrollmentDO);
                return Created("", enrollmentDO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollmentDO([FromRoute] int id)
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