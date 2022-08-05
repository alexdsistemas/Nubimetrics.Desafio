namespace Services
{
    public interface IPort<T>
    {
        ValueTask Handle(T dto);
    }
    public interface IPort
    {
        ValueTask Handle();
    }
}
