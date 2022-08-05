namespace ExceptionHandler
{
    public class BadRequestException : Exception
    {
        public string? Detail { get; set; }
        public BadRequestException() { }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception innerException) :
            base(message, innerException)
        { }

        public BadRequestException(string title, string detail) :
            base(title) => Detail = detail;
    }
}
