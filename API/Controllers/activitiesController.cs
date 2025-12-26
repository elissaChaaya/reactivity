using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class activitiesController(AppDbContext context) : BaseAPIController //primary constructor [netween the paranthesis] 
{
   [HttpGet]
   public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")] ///curly brackets mean that the ID will be replaced by an actual one
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        var activity = await context.Activities.FindAsync(id); //find only can be used by searching with the PK
        
        if(activity == null) return NotFound();

        return activity; 
    }
}
