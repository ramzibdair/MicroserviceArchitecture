using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Order.Domain.Abstraction;
using Order.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Infrastructure.EntityFramework.Interceptors
{
    internal class ConvertDomainEventToOutboxMessageInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;
            if(dbContext is not null)
            {
                var outboxMessage = dbContext.ChangeTracker
                     .Entries<AggregateRoot>()
                     .Select(a => a.Entity)
                     .SelectMany(aggregate => {
                         var domainEvents = aggregate.GetDomianEvent();
                         aggregate.ClearDomianEvent();
                         return domainEvents;
                     })
                     .Select(aggregate => new OutboxMessage
                     {
                         Id = Guid.NewGuid(),
                         Type = aggregate.GetType().Name,
                         CreatedDate= DateTime.UtcNow,
                         Content= JsonConvert.SerializeObject(aggregate,new JsonSerializerSettings
                         {
                             TypeNameHandling= TypeNameHandling.All,
                         })
                     })
                    .ToList();
                dbContext.Set<OutboxMessage>().AddRange(outboxMessage);

            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
