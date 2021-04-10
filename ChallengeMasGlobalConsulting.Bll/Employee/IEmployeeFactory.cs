using Core.Common.Enum;
using Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeMasGlobalConsulting.Bll.Employee
{
    public interface IEmployeeFactory
    {
        Core.Model.Employee.Employee GetEmployee(EmployeeResponseDto employee);
    }
}
