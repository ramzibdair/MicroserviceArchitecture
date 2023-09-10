using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Order.Domain.Abstraction;
using Order.Domain.Entities;
using Quartz;
using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Order.Infrastructure.BackgroundJobs
{
    public class ProcessOutboxMessagesJob : IJob
    {
        private readonly DbContext _bdContext;
        private readonly IPublisher _pulisher;

        public ProcessOutboxMessagesJob(DbContext bdContext, IPublisher pulisher)
        {
            _bdContext = bdContext;
            _pulisher = pulisher;
        }



        public async Task Execute(IJobExecutionContext context)
        {
            var messages = await _bdContext.Set<OutboxMessage>()
                .Where(m => m.ProcessOn == null)
                .Take(20)
                .ToListAsync(context.CancellationToken);
            foreach(var message in messages)
            {
                IDomianEvent? domianEvent = JsonConvert.DeserializeObject<IDomianEvent>(message.Content);
                if(domianEvent is  null)
                {
                    continue;
                }
                try
                {
                    await _pulisher.Publish(domianEvent, context.CancellationToken);
                }
                catch (Exception ex)
                {
                    //add logger 
                }
                message.ProcessOn = DateTime.UtcNow;
            }
           await _bdContext.SaveChangesAsync();
        }
    }
}
