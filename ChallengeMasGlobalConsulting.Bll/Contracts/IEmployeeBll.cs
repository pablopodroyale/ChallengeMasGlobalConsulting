using Core.Dto.Response;
using Core.Model.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMasGlobalConsulting.Bll.Contracts
{
    public interface IEmployeeBll
    {
        Task<ICollection<Core.Model.Employee.Employee>> GetAllEmployeesAsync(Core.Dto.SearchDto searchDto);
        Task<Core.Model.Employee.Employee> GetEmployeeByIdAsync(int id);
    }
}
