using System.Threading.Tasks;
using AutoMapper;
using MasGlobal.Employees.Business.Exceptions;
using MasGlobal.Employees.Business.Factories;
using MasGlobal.Employees.Business.Model;
using MasGlobal.Employees.Business.Services;
using MasGlobal.Employees.DataAccess.Repository;
using Moq;
using NUnit.Framework;
using Employee = MasGlobal.Employees.DataAccess.Model.Employee;

namespace MasGlobal.Employees.Business.Specs
{
    [TestFixture]
    public class EmployeeSpecs
    {
        [Test]
        public async Task Should_Calculate_Correctly_Annual_Salary_When_Contract_Is_Hourly()
        {
            var mapper = new Mock<IMapper>();
            var employeesRepository = new Mock<IEmployeesRepository>();
            var employeeInfo = new Employee
            {
                ContractTypeName = "HourlySalaryEmployee",
                HourlySalary = 60000
            };

            employeesRepository.Setup(x => x.GetEmployeAsync(1)).Returns(Task.FromResult(employeeInfo));

            mapper.Setup(x => x.Map<HourlyEmployee>(employeeInfo)).Returns(
                new HourlyEmployee
                {
                    ContractType = ContractType.HourlySalaryEmployee,
                    Salary = employeeInfo.HourlySalary
                }
            );

            var employeesFactory = new EmployeeFactory(mapper.Object);
            var service = new EmployeeService(employeesRepository.Object, employeesFactory);
            var employee = await service.GetEmployeeAsync(1);

            Assert.NotNull(employee);
            Assert.IsInstanceOf(typeof(HourlyEmployee), employee);
            Assert.AreEqual(employee.AnnualSalary, 86400000);
        }

        [Test]
        public async Task Should_Calculate_Correctly_Annual_Salary_When_Contract_Is_Monthly()
        {
            var mapper = new Mock<IMapper>();
            var employeesRepository = new Mock<IEmployeesRepository>();
            var employeeInfo = new Employee
            {
                ContractTypeName = "MonthlySalaryEmployee",
                HourlySalary = 80000
            };

            employeesRepository.Setup(x => x.GetEmployeAsync(1)).Returns(Task.FromResult(employeeInfo));

            mapper.Setup(x => x.Map<MonthlyEmployee>(employeeInfo)).Returns(
                new MonthlyEmployee
                {
                    ContractType = ContractType.MonthlySalaryEmployee,
                    Salary = employeeInfo.HourlySalary
                }
            );

            var employeesFactory = new EmployeeFactory(mapper.Object);
            var service = new EmployeeService(employeesRepository.Object, employeesFactory);
            var employee = await service.GetEmployeeAsync(1);

            Assert.NotNull(employee);
            Assert.IsInstanceOf(typeof(MonthlyEmployee), employee);
            Assert.AreEqual(employee.AnnualSalary, 960000);
        }

        [Test]
        public void Should_Fails_When_ContractType_Is_Invalid()
        {
            var mapper = new Mock<IMapper>();
            var employeesRepository = new Mock<IEmployeesRepository>();
            var employeeInfo = new Employee
            {
                ContractTypeName = "WeeklySalaryEmployee",
                HourlySalary = 80000
            };

            employeesRepository.Setup(x => x.GetEmployeAsync(1)).Returns(Task.FromResult(employeeInfo));

            var employeesFactory = new EmployeeFactory(mapper.Object);
            var service = new EmployeeService(employeesRepository.Object, employeesFactory);

            var exception = Assert.ThrowsAsync<EmployeeBusinessException>(async () =>
            {
                var employee = await service.GetEmployeeAsync(1);
            });

            Assert.NotNull(exception);
            Assert.AreEqual(exception.Message, "Unable to determine employee contract type.");
        }
    }
}
