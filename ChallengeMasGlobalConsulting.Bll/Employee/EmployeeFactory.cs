using Core.Common.Enum;
using Core.Common.Exception;
using Core.Dto.Response;
using Core.Model.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeMasGlobalConsulting.Bll.Employee
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Core.Model.Employee.Employee GetEmployee(EmployeeResponseDto employeeResponseDto)
        {
            Core.Model.Employee.Employee employee = null;
            switch (employeeResponseDto.contractTypeName)
            {
                case EmployeesEnum.HourlySalaryEmployee:
                    employee =  new HourlySalaryEmployee(employeeResponseDto);
                    break;
                case EmployeesEnum.MonthlySalaryEmployee:
                    employee = new MonthlySalaryEmployee(employeeResponseDto);
                    break;
                default:
                    throw new EmployeeNotSupportedException();
            }

            return employee;
        }
    }
}
