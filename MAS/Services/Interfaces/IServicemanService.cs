using MAS.Data.DTO;

namespace MAS.Services.Interfaces;

public interface IServicemanService
{
    Task<IEnumerable<SomeServiceman>> GetServicemenBySkill(int skill);
}