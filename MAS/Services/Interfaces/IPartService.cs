using MAS.Data;
using MAS.DTO;

namespace MAS.Services.Interfaces;

public interface IPartService
{
    Task<SomePart> GetPart(int IdPart);
    Task<IEnumerable<Part>> GetParts();
}