namespace ExceptionHandler
{
    public class UpdateException : Exception
    {
        public IReadOnlyList<string> Entries { get; set; } = null!;
        public UpdateException() { }
        public UpdateException(string message) : base(message) { }
        public UpdateException(string message, Exception innerException) :
            base(message, innerException)
        { }

        public UpdateException(string message,
            IReadOnlyList<string> entries) : base(message) =>
            Entries = entries;
    }
}
