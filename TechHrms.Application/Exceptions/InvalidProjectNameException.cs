using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHrms.Application.Exceptions
{
    public class InvalidProjectNameException : Exception
    {
        public readonly int ErrorCode;

        public InvalidProjectNameException()
            : base("Invalid Project name.")
        {
            ErrorCode = -1;
        }

        public InvalidProjectNameException(string message)
            : base(message)
        {
            ErrorCode = -1;
        }

        public InvalidProjectNameException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public InvalidProjectNameException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

    }
}
