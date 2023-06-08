using MAS.Data;
using MAS.Data.DTO;
using MAS.DTO;
using MAS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MAS.Services.Repositories;

public class JobService : IJobService
{
    private readonly MasContext _dbContext;

    public JobService(MasContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<SomeJob>> GetJobs()
    {
        return await _dbContext.Jobs
            .Select(job => new SomeJob()
            {
                IdJob = job.IdJob,
                StartDate = job.Start,
                EndDate = job.End,
                Cost = job.Cost,
                Status = job.Status,
                Plates = job.IdCarNavigation.Plates,
                EmployeeFname = job.ServicemanIdPersonNavigation.IdPersonNavigation.FirstName,
                EmployeeLname = job.ServicemanIdPersonNavigation.IdPersonNavigation.LastName
            }).ToListAsync();
    }

    public async Task<JobDetails> GetJob(int IdJob)
    {
        var job = await _dbContext.Jobs.FirstOrDefaultAsync(job => job.IdJob.Equals(IdJob));
        var car = await _dbContext.Cars.FirstOrDefaultAsync(car => car.IdCar == job.IdCar);
        var person = await _dbContext.People.FirstOrDefaultAsync(person => person.IdPerson == job.IdPerson);

        var overviewIds = _dbContext.Overviews
            .Join(_dbContext.Jobs, o => o.IdJob, j => j.IdJob, (o, j) => new { o, j })
            .Where(result => result.j.IdJob == result.o.IdJob)
            .Select(result => result.o.IdOverview)
            .ToList();

        var kongo = _dbContext.ServiceActivities
            .Where(obj => overviewIds.Contains(obj.IdOverviewNavigation.IdOverview))
            .Where(j => j.IdOverviewNavigation.IdJob == job.IdJob)
            .Select(obj => new SomeOverview
            {
                Name = obj.Name,
                DifficultyLevel = obj.DifficultyLevel,
                ServiceDate = obj.ServiceDate,
                Cost = obj.IdOverviewNavigation.Cost
            }).ToList();
        
        var elementIds = _dbContext.Elements
            .Join(_dbContext.PaintingElements, e => e.IdElement, pe => pe.IdElement, (e, pe) => new { e, pe })
            .Join(_dbContext.Jobs, joinResult => joinResult.pe.IdJob, j => j.IdJob, (joinResult, j) => new { joinResult, j })
            .Where(result => result.j.IdJob == result.joinResult.pe.IdJob)
            .Select(result => result.joinResult.e.IdElement)
            .ToList();

        var elements = _dbContext.ServiceActivities
            .Where(obj => elementIds.Contains(obj.IdPaintingNavigation.IdPainting))
            .Where(sa => sa.IdPaintingNavigation.PaintingElements.Any(j => j.IdJob == job.IdJob))
            .Select(obj => new SomePainting
            {
                Name = obj.Name,
                DifficultyLevel = obj.DifficultyLevel,
                ServiceDate = obj.ServiceDate,
                Colour = obj.IdPaintingNavigation.Colour,
                Elements = obj.IdPaintingNavigation.PaintingElements
                    .Select(ele => new Element
                    {
                        Name = ele.IdElementNavigation.Name,
                        Cost = ele.IdElementNavigation.Cost
                    }).ToList()
            }).ToList();

        var exchangesIds = _dbContext.Parts
            .Join(_dbContext.Replacements, e => e.IdPart, pe => pe.IdPart, (e, pe) => new { e, pe })
            .Join(_dbContext.Jobs, joinResult => joinResult.pe.IdJob, j => j.IdJob, (joinResult, j) => new { joinResult, j })
            .Where(result => result.j.IdJob == result.joinResult.pe.IdJob)
            .Select(result => result.joinResult.e.IdPart)
            .ToList();
        
        var exchanges = _dbContext.ServiceActivities
            .Where(obj => elementIds.Contains(obj.IdPartsExchangeNavigation.IdPartsExchange))
            .Where(sa => sa.IdPartsExchangeNavigation.Replacements.Any(j => j.IdJob == job.IdJob))
            .Select(obj => new SomeReplacement()
            {
                Name = obj.Name,
                DifficultyLevel = obj.DifficultyLevel,
                ServiceDate = obj.ServiceDate,
                Parts = obj.IdPartsExchangeNavigation.Replacements
                    .Select(part => new Part
                    {
                        Name = part.IdPartNavigation.Name,
                        Cost = part.IdPartNavigation.Cost
                    }).ToList()
            }).ToList();
        
        JobDetails jobDetails = new JobDetails
        {
            IdJob = job.IdJob,
            StartDate = job.Start,
            EndDate = job.End,
            Cost = job.Cost,
            Status = job.Status,
            Note = job.Note,
            IdCar = job.IdCar,
            IdPerson = job.IdPerson,
            Plates = car.Plates,
            Brand = car.Brand,
            Model = car.Model,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Overviews = kongo,
            Paintings = elements,
            Replacements = exchanges
        };
        return jobDetails;
    }

    /*public async Task CreateJob(Job job, List<Overview> overviews, List<Painting> paintings, List<PartsExchange> partsExchanges)
    {
        
        
        
        Overview overview = new Overview
        {
            
        };
            
            
            
        var finalCost = 0;
        if (!job.Paintings.IsNullOrEmpty())
        {
            foreach (var painting in job.Paintings)
            {
                finalCost += painting.Elements.Sum(obj => obj.Cost);
            }
        }

        if (!job.PartsExchanges.IsNullOrEmpty())
        {
            foreach (var exchange in job.PartsExchanges)
            {
                finalCost += exchange.Parts.Sum(obj => obj.Cost);
            }
        }

        if (!job.Overviews.IsNullOrEmpty())
        {
            finalCost += job.Overviews.Sum(obj => obj.Cost);
        }

        
        await _dbContext.SaveChangesAsync();
    }*/
}