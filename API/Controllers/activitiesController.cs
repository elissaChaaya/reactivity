using System;
using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class activitiesController: BaseAPIController //can use and take the protected paramters from BaseAPIController
{
   [HttpGet]
   public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
    {
        return await Mediator.Send(new GetActivityList.Query(), ct);
    }

    [HttpGet("{id}")] ///curly brackets mean that the ID will be replaced by an actual one
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
       return await Mediator.Send(new GetActivityDetails.Query{Id = id});
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
       return await Mediator.Send(new Application.Activities.Commands.CreateActivity.Command{Activity = activity});
    }

    [HttpPut]
    public async Task<ActionResult> EditActivity(Activity activity)
    {
       await Mediator.Send(new EditActivity.Command{Activity = activity});
       return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
       await Mediator.Send(new deleteActivity.Command{Id = id});
       return Ok();
    }


}
