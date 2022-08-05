namespace Services
{
    public interface IPresenter<FormatDataType>
    {
        FormatDataType Content { get; }
    }
}
