using Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Employee
{
    public abstract class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Role.Role Role { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }

        public Employee(EmployeeResponseDto employee)
        {
            this.ID = employee.id;
            this.Name = employee.name;
            this.HourlySalary = employee.hourlySalary;
            this.MonthlySalary = employee.monthlySalary;
            this.Role = new Role.Role
            {
                RoleId = employee.roleId,
                RoleName = employee.roleName,
                RoleDescription = employee.roleDescription
            };
        }

        protected abstract double GetSalary();
    }
}
