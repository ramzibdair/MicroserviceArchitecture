using Order.Domain.Abstraction;


namespace Order.Domain.DomainEvents
{
    public sealed record OrderCreatedDomainEvent(string UserName , int OrderId) : IDomianEvent;
    
}
