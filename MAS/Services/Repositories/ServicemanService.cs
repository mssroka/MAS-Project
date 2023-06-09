using MAS.Data.DTO;
using MAS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MAS.Services.Repositories;

public class ServicemanService : IServicemanService
{
    private readonly MasContext _dbContext;

    public ServicemanService(MasContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<SomeServiceman>> GetServicemenBySkill(int skill)
    {
        return await _dbContext.Servicemen
            .Where(e => e.Skills >= skill)
            .Select(s => new SomeServiceman()
            {
                IdPerson = s.IdPerson,
                Skills = s.Skills,
                FirstName = s.IdPersonNavigation.FirstName,
                LastName = s.IdPersonNavigation.LastName
            }).ToListAsync();
    }
}