using MAS.Data;
using MAS.DTO;

namespace MAS.Services.Interfaces;

public interface IElementService
{
    Task<SomeELement> GetElement(int IdElement);
    Task<IEnumerable<Element>> GetElements();

}