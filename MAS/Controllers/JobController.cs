﻿using MAS.Data.DTO;
using MAS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Controllers;

[Route("api/jobs")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetJobs()
    {
        return Ok(await _jobService.GetJobs());
    }

    [HttpGet("{IdJob}")]
    public async Task<IActionResult> GetJob(int IdJob)
    {
        return Ok(await _jobService.GetJob(IdJob));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateJob(JobCreation jobCreation)
    {
        if (jobCreation.OverviewJobCreation is null
            && jobCreation.ReplacementJobCreation is null
            && jobCreation.PaintingJobCreation is null)
            return BadRequest("Empty objects");
        await _jobService.CreateJob(jobCreation);
        return Ok("Job created");
    }
}