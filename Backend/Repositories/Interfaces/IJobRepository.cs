using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job?> GetJobByIdAsync(int id);
        Task<IEnumerable<Job>> GetJobsByEmployerIdAsync(int employerId);
        Task<Job> CreateJobAsync(Job job);
        Task<Job> UpdateJobAsync(Job job);
        Task<bool> DeleteJobAsync(int id);
        Task<bool> JobExistsAsync(int id);
    }
}