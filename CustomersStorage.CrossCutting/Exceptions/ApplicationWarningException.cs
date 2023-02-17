
namespace CustomersStorage.CrossCutting.Exceptions
{
    public class ApplicationWarningException : ApplicationException
    {
        public ApplicationWarningException()
        {
        }

        public ApplicationWarningException(string message)
            : base(message)
        {
        }

        public ApplicationWarningException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
