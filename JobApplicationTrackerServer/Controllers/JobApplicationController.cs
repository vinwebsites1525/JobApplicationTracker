using JobApplicationTrackerServer.Models;
using JobApplicationTrackerServer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTrackerServer.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationRepository _repository;

        public JobApplicationController(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<JobApplication>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetById(int id)
        {
            var application = await _repository.GetByIdAsync(id);

            if(application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }  

        [HttpPost("Create")]
        public async Task<IActionResult> Create(JobApplication application)
        {
            await _repository.AddAsync(application);
            return CreatedAtAction(nameof(GetById), new { id = application.Id}, application);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, JobApplication application)
        {
            if(id != application.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync(application);
            return NoContent();
        }
    }
