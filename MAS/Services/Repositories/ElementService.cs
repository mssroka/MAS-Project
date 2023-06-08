using MAS.Data;
using MAS.DTO;
using MAS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MAS.Services.Repositories;

public class ElementService : IElementService
{
    private readonly MasContext _dbContext;

    public ElementService(MasContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<SomeELement> GetElement(int idElement)
    {
        return await _dbContext.Elements.Where(e => e.IdElement.Equals(idElement))
            .Select(part => new SomeELement()
            {
                Name = part.Name,
                Cost = part.Cost
            }).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Element>> GetElements()
    {
        return await _dbContext.Elements
            .Select(element => new Element()
            {
                IdElement = element.IdElement,
                Name = element.Name,
                Cost = element.Cost
            }).ToListAsync();
    }
}