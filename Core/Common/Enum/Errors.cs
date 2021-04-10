using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Common.Enum
{
    public enum Errors
    {
        [Description("Error, fetching employees")]
        ERROR_GET_EMPLOYEES,
        [Description("Error employee {0} not found")]
        ERROR_EMPLOYEE_NOT_FOUND
    }
}
