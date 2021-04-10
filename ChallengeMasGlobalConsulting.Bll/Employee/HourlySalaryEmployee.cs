using Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeMasGlobalConsulting.Bll.Employee
{
    public class HourlySalaryEmployee : Core.Model.Employee.Employee
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
