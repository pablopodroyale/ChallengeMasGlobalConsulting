using Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Employee
{
    public class HourlySalaryEmployee : Employee
    {
        public HourlySalaryEmployee(EmployeeResponseDto employee) : base(employee)
        {
        }

        protected override double GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
