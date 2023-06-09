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
        var job = await _dbContext.Jobs.FirstOrDefaultAsync(job => job.IdJob == IdJob);
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
            .Where(obj => exchangesIds.Contains(obj.IdPartsExchangeNavigation.IdPartsExchange))
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
        
        var diagnose = await _dbContext.Diagnoses.FirstOrDefaultAsync(diag => diag.IdJob == job.IdJob);
        
        JobDetails jobDetails = new JobDetails
        {
            IdJob = job.IdJob,
            StartDate = job.Start,
            EndDate = job.End,
            Cost = job.Cost,
            Status = job.Status,
            Note = job.Note,
            Diagnose = diagnose.DiagText,
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

    public async Task CreateJob(JobCreation jobCreation)
    {
        Job job = new Job
        {
            Start = jobCreation.DateStart,
            End = jobCreation.DateEnd,
            Cost = jobCreation.finalCost,
            Status = "Created",
            Note = jobCreation.Note,
            IdCar = jobCreation.idCar,
            IdPerson = jobCreation.idServiceman,
        };

        _dbContext.Jobs.Add(job);
        await _dbContext.SaveChangesAsync();

        if (jobCreation.OverviewJobCreation is not null)
        {
            Overview overview = new Overview
            {
                Cost = Overview.OverviewCost,
                IdJob = job.IdJob
            };

            _dbContext.Overviews.Add(overview);
            await _dbContext.SaveChangesAsync();
            
            ServiceActivity serviceActivity = new ServiceActivity
            {
                Name = Overview.OverviewName,
                DifficultyLevel = jobCreation.OverviewJobCreation.DifficultyLevel,
                ServiceDate = jobCreation.OverviewJobCreation.ServiceDate,
                IdOverview = overview.IdOverview
            };
            _dbContext.ServiceActivities.Add(serviceActivity);
            await _dbContext.SaveChangesAsync();

            if (jobCreation.PaintingJobCreation is not null)
            {
                Painting painting = new Painting
                {
                    Colour = jobCreation.PaintingJobCreation.Colour,
                };
                _dbContext.Paintings.Add(painting);
                await _dbContext.SaveChangesAsync();

                foreach (var ids in jobCreation.PaintingJobCreation.ElementsIds)
                {
                    PaintingElement pe = new PaintingElement
                    {
                        IdElement = ids,
                        IdPainting = painting.IdPainting,
                        IdJob = job.IdJob
                    };
                    _dbContext.PaintingElements.Add(pe);
                    await _dbContext.SaveChangesAsync();
                }

                ServiceActivity sa2 = new ServiceActivity
                {
                    Name = Painting.PaintingName,
                    DifficultyLevel = jobCreation.PaintingJobCreation.DifficultyLevel,
                    ServiceDate = jobCreation.PaintingJobCreation.ServiceDate,
                    IdPainting = painting.IdPainting
                };
                _dbContext.ServiceActivities.Add(sa2);
                await _dbContext.SaveChangesAsync();
            }

            if (jobCreation.ReplacementJobCreation is not null)
            {
                PartsExchange pe = new PartsExchange {};
                _dbContext.PartsExchanges.Add(pe);
                await _dbContext.SaveChangesAsync();

                foreach (var ids in jobCreation.ReplacementJobCreation.PartsIds)
                {
                    Replacement replacement = new Replacement
                    {
                        IdPartsExchange = pe.IdPartsExchange,
                        IdJob = job.IdJob,
                        IdPart = ids
                    };
                    _dbContext.Replacements.Add(replacement);
                    await _dbContext.SaveChangesAsync();
                }

                ServiceActivity sa3 = new ServiceActivity
                {
                    Name = PartsExchange.PEName,
                    DifficultyLevel = jobCreation.ReplacementJobCreation.DifficultyLevel,
                    ServiceDate = jobCreation.ReplacementJobCreation.ServiceDate,
                    IdPartsExchange = pe.IdPartsExchange
                };
                _dbContext.ServiceActivities.Add(sa3);
                await _dbContext.SaveChangesAsync();

            }
        }
    }
}