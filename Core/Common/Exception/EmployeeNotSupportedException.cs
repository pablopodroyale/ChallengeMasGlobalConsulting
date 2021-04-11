using Core.Common.Enum;
using Core.Common.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Exception
{
    public class EmployeeNotSupportedException: System.Exception
    {
        public EmployeeNotSupportedException() : base(Errors.ERROR_EMPLOYEE_NOT_SUPPORTED.GetDescription())
        {

        }
    }
}
