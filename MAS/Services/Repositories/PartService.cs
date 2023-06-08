using MAS.Data;
using MAS.DTO;
using MAS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MAS.Services.Repositories;

public class PartService : IPartService
{
    private readonly MasContext _dbContext;

    public PartService(MasContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<SomePart> GetPart(int IdPart)
    {
        return await _dbContext.Parts
            .Where(part => part.IdPart.Equals(IdPart))
            .Select(part => new SomePart()
            {
                Name = part.Name,
                Cost = part.Cost
            }).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Part>> GetParts()
    {
        return await _dbContext.Parts
            .Select(part => new Part()
            {
                IdPart = part.IdPart,
                Name = part.Name,
                Cost = part.Cost
            }).ToListAsync();
    }
}