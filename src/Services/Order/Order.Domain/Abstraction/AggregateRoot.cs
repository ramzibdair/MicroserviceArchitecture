

using System.Collections.Generic;
using System.Linq;

namespace Order.Domain.Abstraction
{
    public abstract class AggregateRoot : EntityBase, IAggregateRoot
    {
        private static readonly List<IDomianEvent> _domianEvents;
        //protected AggregateRoot() { }
        public IReadOnlyCollection<IDomianEvent> GetDomianEvent() => _domianEvents;

        public void ClearDomianEvent() => _domianEvents.Clear();
        protected static void RaiseEvent(IDomianEvent domianEvent)
        {
            _domianEvents.Add(domianEvent);
        }
    }
}
