using ChallengeMasGlobalConsulting.Bll;
using ChallengeMasGlobalConsulting.Bll.Employee;
using ChallengeMasGlobalConsulting.Dal.Contracts;
using Core.Common.Exception;
using Core.Dto;
using Core.Dto.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMasGlobalConsulting.Test.Bll
{
    [TestClass]
    public class EmployeesBllTest
    {
        private EmployeeBll target;
        private Mock<IEmployeeDal> employeeDalMock;
        private Mock<IEmployeeFactory> employeeFactoryMock;
        private Mock<ILogger> loggerMock;

        [TestInitialize]
        public void Setup()
        {
            this.employeeDalMock = new Mock<IEmployeeDal>();
            this.employeeFactoryMock = new Mock<IEmployeeFactory>();
            this.loggerMock = new Mock<ILogger>();
            target = new EmployeeBll(employeeDalMock.Object, employeeFactoryMock.Object, loggerMock.Object);
        }

        [TestMethod]
        public async Task GetAllEmployeesReturnsHourlySalaryEmployeeOk()
        {
            EmployeeResponseDto employeeResponseDtoToReturn = new EmployeeResponseDto
            {
                id = 1,
                name = "test",
                contractTypeName = Core.Common.Enum.EmployeesEnum.HourlySalaryEmployee,
                roleId = 1,
                roleName = "testRole",
                roleDescription = null,
                hourlySalary = 10,
                monthlySalary = 100
            };

            ResponseDto<ICollection<EmployeeResponseDto>> responseToReturn = new ResponseDto<ICollection<EmployeeResponseDto>>
            {
                Status = 200,
                Content = new List<EmployeeResponseDto>
                {
                    employeeResponseDtoToReturn
                }
            };

            double annualSalaryExpected = 120 * employeeResponseDtoToReturn.hourlySalary * 12;

            Core.Model.Employee.Employee employee = new Core.Model.Employee.HourlySalaryEmployee(employeeResponseDtoToReturn);
           

            this.employeeDalMock.Setup(x => x.GetAsync())
                                .ReturnsAsync(responseToReturn);

            EmployeeResponseDto employeeResponseDto = null;
            this.employeeFactoryMock.Setup(x => x.GetEmployee(It.IsAny<EmployeeResponseDto>()))
                                     .Callback((EmployeeResponseDto employeeResponseDtoParameter) => employeeResponseDto = employeeResponseDtoParameter)
                                     .Returns(employee);

            var result = await target.GetAllEmployeesAsync(null);

            Assert.AreEqual(1, result.Count());
            Assert.IsInstanceOfType(result.FirstOrDefault(), typeof(Core.Model.Employee.HourlySalaryEmployee));
            Assert.AreEqual(responseToReturn.Content.FirstOrDefault().id, result.FirstOrDefault().ID);
            Assert.AreEqual(employeeResponseDtoToReturn, employeeResponseDto);
            Assert.AreEqual(annualSalaryExpected, result.FirstOrDefault().CalculatedAnnualSalary);
        }

        [TestMethod]
        public async Task GetAllEmployeesReturnsMonthlySalaryEmployeeOk()
        {
            EmployeeResponseDto employeeResponseDtoToReturn = new EmployeeResponseDto
            {
                id = 1,
                name = "test",
                contractTypeName = Core.Common.Enum.EmployeesEnum.MonthlySalaryEmployee,
                roleId = 1,
                roleName = "testRole",
                roleDescription = null,
                hourlySalary = 10,
                monthlySalary = 100
            };

            ResponseDto<ICollection<EmployeeResponseDto>> responseToReturn = new ResponseDto<ICollection<EmployeeResponseDto>>
            {
                Status = 200,
                Content = new List<EmployeeResponseDto>
                {
                    employeeResponseDtoToReturn
                }
            };

            double annualSalaryExpected = employeeResponseDtoToReturn.monthlySalary * 12;

            Core.Model.Employee.Employee employee = new Core.Model.Employee.MonthlySalaryEmployee(employeeResponseDtoToReturn);

            this.employeeDalMock.Setup(x => x.GetAsync())
                                .ReturnsAsync(responseToReturn);

            EmployeeResponseDto employeeResponseDto = null;
            this.employeeFactoryMock.Setup(x => x.GetEmployee(It.IsAny<EmployeeResponseDto>()))
                                     .Callback((EmployeeResponseDto employeeResponseDtoParameter) => employeeResponseDto = employeeResponseDtoParameter)
                                     .Returns(employee);

            var result = await target.GetAllEmployeesAsync(null);

            Assert.AreEqual(1, result.Count());
            Assert.IsInstanceOfType(result.FirstOrDefault(), typeof(Core.Model.Employee.MonthlySalaryEmployee));
            Assert.AreEqual(responseToReturn.Content.FirstOrDefault().id, result.FirstOrDefault().ID);
            Assert.AreEqual(employeeResponseDtoToReturn, employeeResponseDto);
            Assert.AreEqual(annualSalaryExpected, result.FirstOrDefault().CalculatedAnnualSalary);
        }

        [TestMethod]
        public async Task GetAllEmployeesFilteredOk()
        {
            EmployeeResponseDto employeeResponseDtoToReturn = new EmployeeResponseDto
            {
                id = 1,
                name = "test",
                contractTypeName = Core.Common.Enum.EmployeesEnum.MonthlySalaryEmployee,
                roleId = 1,
                roleName = "testRole",
                roleDescription = null,
                hourlySalary = 10,
                monthlySalary = 100
            };

            EmployeeResponseDto secondEmployeeResponseDtoToReturn = new EmployeeResponseDto
            {
                id = 2,
                name = "test2",
                contractTypeName = Core.Common.Enum.EmployeesEnum.HourlySalaryEmployee,
                roleId = 1,
                roleName = "testRole",
                roleDescription = null,
                hourlySalary = 10,
                monthlySalary = 100
            };

            ResponseDto<ICollection<EmployeeResponseDto>> responseToReturn = new ResponseDto<ICollection<EmployeeResponseDto>>
            {
                Status = 200,
                Content = new List<EmployeeResponseDto>
                {
                    employeeResponseDtoToReturn,
                    secondEmployeeResponseDtoToReturn
                }
            };

            SearchDto searchDto = new SearchDto
            {
                Asc = true,
                Id = 1,
                PageLength = 1
            };

            double annualSalaryExpected = employeeResponseDtoToReturn.monthlySalary * 12;

            Core.Model.Employee.Employee employee = new Core.Model.Employee.MonthlySalaryEmployee(employeeResponseDtoToReturn);

            this.employeeDalMock.Setup(x => x.GetAsync())
                                .ReturnsAsync(responseToReturn);

            EmployeeResponseDto employeeResponseDto = null;
            this.employeeFactoryMock.Setup(x => x.GetEmployee(It.IsAny<EmployeeResponseDto>()))
                                     .Callback((EmployeeResponseDto employeeResponseDtoParameter) => employeeResponseDto = employeeResponseDtoParameter)
                                     .Returns(employee);

            var result = await target.GetAllEmployeesAsync(searchDto);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(responseToReturn.Content.FirstOrDefault().id, result.FirstOrDefault().ID);
            Assert.AreEqual(employeeResponseDtoToReturn, employeeResponseDto);
        }

        [TestMethod]
        public async Task GetAllEmployeesFactoryReturnsWrongEmployee()
        {
            EmployeeResponseDto employeeResponseDtoToReturn = new EmployeeResponseDto
            {
                contractTypeName = default,
            };

            ResponseDto<ICollection<EmployeeResponseDto>> responseToReturn = new ResponseDto<ICollection<EmployeeResponseDto>>
            {
                Status = 200,
                Content = new List<EmployeeResponseDto>
                {
                    employeeResponseDtoToReturn
                }
            };

            Core.Model.Employee.Employee employee = new Core.Model.Employee.MonthlySalaryEmployee(employeeResponseDtoToReturn);

            this.employeeDalMock.Setup(x => x.GetAsync())
                                .ReturnsAsync(responseToReturn);

            this.employeeFactoryMock.Setup(x => x.GetEmployee(It.IsAny<EmployeeResponseDto>()))
                                     .Throws(new EmployeeNotSupportedException());
            loggerMock.Setup(x => x.Error(It.IsAny<string>()))
                      .Verifiable();

            var result = await target.GetAllEmployeesAsync(null);

            Assert.AreEqual(0, result.Count());
            loggerMock.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task GetAllEmployeesException()
        {
            EmployeeResponseDto employeeResponseDtoToReturn = new EmployeeResponseDto
            {
                contractTypeName = default,
            };

            ResponseDto<ICollection<EmployeeResponseDto>> responseToReturn = new ResponseDto<ICollection<EmployeeResponseDto>>
            {
                Status = 200,
                Content = new List<EmployeeResponseDto>
                {
                    employeeResponseDtoToReturn
                }
            };

            Core.Model.Employee.Employee employee = new Core.Model.Employee.MonthlySalaryEmployee(employeeResponseDtoToReturn);

            this.employeeDalMock.Setup(x => x.GetAsync())
                                .Throws(new Exception());

            loggerMock.Setup(x => x.Error(It.IsAny<string>()))
                      .Verifiable();
            Exception exception = null;
            try
            {
                var result = await target.GetAllEmployeesAsync(null);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(true, exception != null);
            loggerMock.Verify(x => x.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
