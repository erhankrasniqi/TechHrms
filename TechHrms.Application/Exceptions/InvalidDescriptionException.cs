using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHrms.Application.Exceptions
{
    public class InvalidDescriptionException : Exception
    {
        public readonly int ErrorCode;

        public InvalidDescriptionException()
            : base("Invalid Descriptin.")
        {
            ErrorCode = -1;
        }

        public InvalidDescriptionException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public InvalidDescriptionException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public InvalidDescriptionException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

    }
}
