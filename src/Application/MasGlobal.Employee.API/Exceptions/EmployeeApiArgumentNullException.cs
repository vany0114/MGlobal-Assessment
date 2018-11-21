using System;

namespace MasGlobal.Employee.API.Exceptions
{
    public class EmployeeApiArgumentNullException : ArgumentNullException
    {
        public EmployeeApiArgumentNullException()
        { }

        public EmployeeApiArgumentNullException(string message)
            : base(message)
        { }

        public EmployeeApiArgumentNullException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
