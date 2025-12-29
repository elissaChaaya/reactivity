using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities.Queries;

public class GetActivityList
{
   public class Query : IRequest<List<Activity>> {} //using the IRequest from the mediatr, it tells mediatr when the query/request  is sent 

    public class Handler(AppDbContext context, ILogger<GetActivityList> logger) : IRequestHandler<Query, List<Activity>>{ //it hadnels the query/request and returns the list of activities 
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {

            try
            {
                for(int i = 0 ; i< 10; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Delay(100, cancellationToken); 
                    logger.LogInformation("Task {TaskNumber} is in progress", i);   
                }

            }catch(Exception ex)
            {
                logger.LogInformation("Task was cancelled");
            }
            return await context.Activities.ToListAsync(cancellationToken);
        }
    }
}
