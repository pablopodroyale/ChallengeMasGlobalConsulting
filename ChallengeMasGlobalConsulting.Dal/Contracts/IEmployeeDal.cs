using Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMasGlobalConsulting.Dal.Contracts
{
    public interface IEmployeeDal 
    {
        Task<ResponseDto<ICollection<EmployeeResponseDto>>> GetAsync();
    }
}
