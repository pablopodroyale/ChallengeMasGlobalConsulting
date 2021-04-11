using ChallengeMasGlobalConsulting.Bll.Contracts;
using ChallengeMasGlobalConsulting.Bll.Employee;
using ChallengeMasGlobalConsulting.Dal.Contracts;
using Core.Common.Enum;
using Core.Common.Exception;
using Core.Common.Helper;
using Core.Model.Employee;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMasGlobalConsulting.Bll
{
    public class EmployeeBll : IEmployeeBll
    {
        private readonly IEmployeeDal employeeDal;
        private readonly ILogger _log;
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeBll(IEmployeeDal employeeDal, IEmployeeFactory employeeFactory, ILogger log)
        {
            this.employeeDal = employeeDal;
            _log = log;
            this._employeeFactory = employeeFactory;
        }
        public async Task<ICollection<Core.Model.Employee.Employee>> GetAllEmployeesAsync()
        {
            List<Error> errors = new List<Error>();
            ICollection<Core.Model.Employee.Employee> ret = new List<Core.Model.Employee.Employee>();
            Core.Model.Employee.Employee employee = null;
            CustomException customException = null;

            try
            {
                var res = await this.employeeDal.GetAsync();
                if (res != null)
                {
                    if (res.Status == 200)
                    {
                        foreach (var item in res.Content)
                        {
                            try
                            {
                                employee = this._employeeFactory.GetEmployee(item);
                                ret.Add(employee);
                            }
                            catch (EmployeeNotSupportedException ex)
                            {
                                this._log.Error(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        throw catchError(errors, ref customException, Errors.ERROR_GET_EMPLOYEES.GetDescription());
                    }
                }
                else
                {
                    throw catchError(errors, ref customException, Errors.ERROR_GET_EMPLOYEES.GetDescription());
                }

                return ret;
            }
            catch (CustomException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw catchException(errors, customException, e);
            }
        }

        public async Task<Core.Model.Employee.Employee> GetEmployeeByIdAsync(int id)
        {
            List<Error> errors = new List<Error>();
            Core.Model.Employee.Employee ret = null;
            CustomException customException = null;

            try
            {
                var res = await this.employeeDal.GetAsync();
                if (res != null)
                {
                    if (res.Status == 200)
                    {
                        var emp = res.Content.FirstOrDefault(x => x.id == id);
                        if (emp != null)
                        {
                            ret = this._employeeFactory.GetEmployee(emp);
                        }
                        else
                        {
                            throw catchError(errors, ref customException, string.Format(Errors.ERROR_EMPLOYEE_NOT_FOUND.GetDescription(), id));
                        }
                       
                    }
                    else
                    {
                        throw catchError(errors, ref customException, Errors.ERROR_GET_EMPLOYEES.GetDescription());
                    }
                }
                else
                {
                    throw catchError(errors, ref customException, Errors.ERROR_GET_EMPLOYEES.GetDescription());
                }

                return ret;
            }
            catch (CustomException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw catchException(errors, customException, e);
            }
        }

        private CustomException catchException(List<Error> errors, CustomException customException, Exception e)
        {
            _log.Error(e.Message);
            errors.Add(new Error(e));
            customException = new CustomException(errors);
            return customException;
        }

        private CustomException catchError(List<Error> errors, ref CustomException customException, string strError)
        {
            _log.Error(strError);
            errors.Add(new Error(strError));
            customException = new CustomException(errors);
            return customException;
        }
    }
}
