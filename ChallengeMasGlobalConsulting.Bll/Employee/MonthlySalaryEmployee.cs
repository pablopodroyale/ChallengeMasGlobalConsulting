using Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeMasGlobalConsulting.Bll.Employee
{
    public class MonthlySalaryEmployee : Core.Model.Employee.Employee
    {
        public MonthlySalaryEmployee(EmployeeResponseDto employee) : base(employee)
        {

        }

        protected override void SetCalculatedAnnualSalary()
        {
            this.CalculatedAnnualSalary = MonthlySalary * 12;
        }
    }
}
