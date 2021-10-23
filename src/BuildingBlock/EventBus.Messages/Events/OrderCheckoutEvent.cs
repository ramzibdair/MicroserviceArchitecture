namespace EventBus.Messages.Events
{
   public class BasketCheckoutEvent : BaseEvent
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
