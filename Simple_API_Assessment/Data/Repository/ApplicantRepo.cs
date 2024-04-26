using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;


namespace Simple_API_Assessment.Data.Repository
{
    public class ApplicantRepo : IApplicantRepository
    {
        private readonly DataContext _context;

        public ApplicantRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Applicant>> GetAllApplicants()
        {
            return await _context.Applicants.Include(a => a.Skills).ToListAsync();
        }

        public async Task<Applicant> GetApplicantById(int id)
        {
            return await _context.Applicants.Include(a => a.Skills).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateApplicant(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateApplicant(int id, Applicant applicant)
        {
            var existingApplicant = await _context.Applicants.FirstOrDefaultAsync(a => a.Id == id);
            if (existingApplicant != null)
            {
                existingApplicant.Name = applicant.Name; 
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteApplicant(int id)
        {
            var existingApplicant = await _context.Applicants.FirstOrDefaultAsync(a => a.Id == id);
            if (existingApplicant != null)
            {
                _context.Applicants.Remove(existingApplicant);
                await _context.SaveChangesAsync();
            }
        }
    }
}
