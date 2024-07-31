using System;

namespace TechHrms.Application.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public readonly int ErrorCode;

        public InvalidEmailException()
            : base("Invalid email address.")
        {
            ErrorCode = -1;
        }

        public InvalidEmailException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public InvalidEmailException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public InvalidEmailException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

    }
}
