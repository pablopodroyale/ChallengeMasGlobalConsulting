﻿using Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Employee
{
    public class MonthlySalaryEmployee : Employee
    {
        public MonthlySalaryEmployee(EmployeeResponseDto employee): base(employee)
        {

        }

        protected override double GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}
