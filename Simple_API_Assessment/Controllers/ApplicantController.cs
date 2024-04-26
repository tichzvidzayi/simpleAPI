using Microsoft.AspNetCore.Mvc;
using Simple_API_Assessment.Data.Repository;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantController(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetApplicants()
        {
            var applicants = await _applicantRepository.GetAllApplicants();
            return Ok(applicants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Applicant>> GetApplicant(int id)
        {
            var applicant = await _applicantRepository.GetApplicantById(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return Ok(applicant);
        }

        [HttpPost]
        public async Task<ActionResult<Applicant>> CreateApplicant(Applicant applicant)
        {
            await _applicantRepository.CreateApplicant(applicant);
            return CreatedAtAction(nameof(GetApplicant), new { id = applicant.Id }, applicant);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateApplicant(int id, Applicant applicant)
        {
            if (id != applicant.Id)
            {
                return BadRequest();
            }
            await _applicantRepository.UpdateApplicant(id, applicant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApplicant(int id)
        {
            var existingApplicant = await _applicantRepository.GetApplicantById(id);
            if (existingApplicant == null)
            {
                return NotFound();
            }
            await _applicantRepository.DeleteApplicant(id);
            return NoContent();
        }
    }
}
