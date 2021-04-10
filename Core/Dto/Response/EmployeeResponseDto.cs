using Core.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.Response
{
    public class EmployeeResponseDto
    {
        public int id { get; set; }
        public string name { get; set; }
        private string _contractTypeName;
        public EmployeesEnum contractTypeName 
        {
            get
            {
                return (EmployeesEnum)Enum.Parse(typeof(EmployeesEnum), _contractTypeName);
            }
            set
            {
                _contractTypeName  = value.ToString();
            }
        }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public double hourlySalary { get; set; }
        public double monthlySalary { get; set; }
    }
}
