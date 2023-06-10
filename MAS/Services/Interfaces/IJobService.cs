using MAS.Data;
using MAS.Data.DTO;
using MAS.DTO;

namespace MAS.Services.Interfaces;

public interface IJobService
{
    
    Task CreateJob(JobCreation jobCreation);
    Task<IEnumerable<SomeJob>> GetJobs();
    Task<JobDetails> GetJob(int IdJob);
    public Task<bool>  ValidateJobCreation(JobCreation jobCreation);
}