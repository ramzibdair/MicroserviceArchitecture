

using System.Collections.Generic;

namespace Order.Domain.Abstraction
{
    public abstract class AggregateRoot : EntityBase, IAggregateRoot
    {
        private readonly List<IDomianEvent> _domianEvents;
        //protected AggregateRoot() { }

        protected void RaiseEvent(IDomianEvent domianEvent)
        {
            _domianEvents.Add(domianEvent);
        }
    }
}
