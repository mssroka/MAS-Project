using MAS.Data;
using MAS.Data.DTO;
using MAS.DTO;

namespace MAS.Services.Interfaces;

public interface IJobService
{
    /*
    Task CreateJob(Job job, List<Overview> overviews, List<Painting> paintings, List<PartsExchange> partsExchanges);
    */
    Task<IEnumerable<SomeJob>> GetJobs();
    Task<JobDetails> GetJob(int IdJob);
}