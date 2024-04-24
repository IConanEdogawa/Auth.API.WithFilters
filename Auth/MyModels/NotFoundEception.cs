namespace Auth.MyModels
{
    // Model пользовательского исключения NotFoundException
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
