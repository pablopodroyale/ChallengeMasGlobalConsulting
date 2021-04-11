using Core.Common.Enum;
using Core.Dto.Response;
using Core.Model.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeMasGlobalConsulting.Bll.Employee
{
    public class EmployeeFactory : IEmployeeFactory
    {
        //private Dictionary<EmployeesEnum, Core.Model.Employee.Employee> _employees;
        //private readonly Core.Model.Employee.HourlySalaryEmployee _hourlySalaryEmployee;
        //private readonly Core.Model.Employee.MonthlySalaryEmployee _monthlySalaryEmployee;

        //public EmployeeFactory(Core.Model.Employee.HourlySalaryEmployee hourlySalaryEmployee, Core.Model.Employee.MonthlySalaryEmployee monthlySalaryEmployee)
        //{
        //    this._hourlySalaryEmployee = hourlySalaryEmployee;
        //    this._monthlySalaryEmployee = monthlySalaryEmployee;
        //    this._employees = new Dictionary<EmployeesEnum, Core.Model.Employee.Employee>
        //    {
        //        {EmployeesEnum.HourlySalaryEmployee, new HourlySalaryEmployee() },
        //        {EmployeesEnum.MonthlySalaryEmployee, this._monthlySalaryEmployee}
        //    };
        //}

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
                    break;
            }

            return employee;
        }
    }
}
