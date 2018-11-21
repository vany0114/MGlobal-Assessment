using System;

namespace MasGlobal.Employees.Business.Exceptions
{
    public class EmployeeBusinessException : Exception
    {
        public EmployeeBusinessException()
        { }

        public EmployeeBusinessException(string message)
            : base(message)
        { }

        public EmployeeBusinessException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
