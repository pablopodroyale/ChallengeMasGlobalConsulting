using ChallengeMasGlobalConsulting.Bll.Contracts;
using Core.Common.Exception;
using Core.Dto.Response;
using Core.Model.Employee;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeMasGlobalConsulting.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBll _employeeBll;
        private readonly ILogger _log;
        public EmployeeController(IEmployeeBll employeeBll, ILogger log)
        {
            this._employeeBll = employeeBll;
            _log = log;
        }

        [HttpGet("")]
        public async Task<ActionResult<ServiceResultDto<ICollection<Employee>>>> GetAllEmployees()
        {
            _log.Information("Calling GetAllEmployees");
            ServiceResultDto<ICollection<Employee>> resultDto = new ServiceResultDto<ICollection<Employee>>();
            List<Error> errors;
            Error error;
            try
            {
                var result = await this._employeeBll.GetAllEmployeesAsync();
                resultDto.Succedded = true;
                resultDto.obj = result.ToList();
                return Ok(resultDto);
            }
            catch (CustomException e)
            {
                _log.Error("Error Details: {0}", e.Errors.FirstOrDefault().Description);
                resultDto.Errors = e.Errors.ToList();
                resultDto.Succedded = false;
                return Ok(resultDto);
            }
            catch (Exception e)
            {
                _log.Error("Error Details: {0}", e);
                errors = new List<Error>();
                error = new Error(e);
                errors.Add(error);
                resultDto.Succedded = false;
                resultDto.Errors = errors;
                return BadRequest(resultDto);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResultDto<Employee>>> GetEmployeeById(string id)
        {
            _log.Information("Calling Get GetEmployeeById Id:", id);
            ServiceResultDto<Employee> resultDto = new ServiceResultDto<Employee>();
            List<Error> errors;
            Error error;
            try
            {
                int idInt = Convert.ToInt32(id);
                var result = await this._employeeBll.GetEmployeeByIdAsync(idInt);
                resultDto.Succedded = true;
                resultDto.obj = result;
                return Ok(resultDto);
            }
            catch (CustomException e)
            {
                _log.Error("Error Details: {0}", e.Errors.FirstOrDefault().Description);
                resultDto.Errors = e.Errors.ToList();
                resultDto.Succedded = false;
                return Ok(resultDto);
            }
            catch (Exception e)
            {
                _log.Error("Error Details: {0}", e);
                errors = new List<Error>();
                error = new Error(e);
                errors.Add(error);
                resultDto.Succedded = false;
                resultDto.Errors = errors;
                return BadRequest(resultDto);
            }
        }
    }
}
