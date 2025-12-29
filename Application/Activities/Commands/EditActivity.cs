using System;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class EditActivity
{
   public class Command : IRequest 
   {
      public required Activity Activity { get; set; }
   }

   public class Handler(AppDbContext context, IMapper mapper): IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken)?? throw new Exception("Cannot find activity"); //get activity from database 

            mapper.Map(request.Activity, activity); //maps the values from request.Activity to activity

            // activity.Title = request.Activity.Title ?? activity.Title;
            // activity.Description = request.Activity.Description ?? activity.Description;
            // activity.Category = request.Activity.Category ??  activity.Category;
            // activity.Date = request.Activity.Date != default ? request.Activity.Date : activity.Date;
            // activity.City = request.Activity.City ?? activity.City;
            // activity.Venue = request.Activity.Venue ?? activity.Venue;  //instead of doing all this, we can use AutoMapper

            await context.SaveChangesAsync(cancellationToken) ;

          
        }
    }
}
