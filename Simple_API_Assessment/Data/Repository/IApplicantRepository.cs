using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public interface IApplicantRepository
    {
        Task<IEnumerable<Applicant>> GetAllApplicants();
        Task<Applicant> GetApplicantById(int id);
        Task CreateApplicant(Applicant applicant);
        Task UpdateApplicant(int id, Applicant applicant);
        Task DeleteApplicant(int id);
    }
}
