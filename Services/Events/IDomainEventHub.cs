namespace Services.Events
{
    public interface IDomainEventHub<EventType>
        where EventType : IDomainEvent
    {
        void Raise(EventType eventTypeInstance);
    }
}
