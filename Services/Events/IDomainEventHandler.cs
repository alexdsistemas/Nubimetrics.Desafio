namespace Services.Events
{
    public interface IDomainEventHandler<EventType> where EventType : IDomainEvent
    {
        void Handle(EventType eventTypeInstance);
    }
}
