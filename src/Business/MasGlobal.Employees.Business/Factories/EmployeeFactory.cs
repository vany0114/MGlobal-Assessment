using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MasGlobal.Employees.Business.Exceptions;
using MasGlobal.Employees.Business.Model;
using Entity = MasGlobal.Employees.DataAccess.Model;

namespace MasGlobal.Employees.Business.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private readonly IMapper _mapper;

        public EmployeeFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Employee CreateEmployee(Entity.Employee employeeInfo)
        {
            return Create(employeeInfo);
        }

        public List<Employee> CreateEmployees(List<Entity.Employee> employeesInfo)
        {
            return employeesInfo.Select(Create).ToList();
        }

        private Employee Create(Entity.Employee employeeInfo)
        {
            Enum.TryParse<ContractType>(employeeInfo.ContractTypeName, out var type);
            switch (type)
            {
                case ContractType.HourlySalaryEmployee:
                    return _mapper.Map<HourlyEmployee>(employeeInfo);
                case ContractType.MonthlySalaryEmployee:
                    return _mapper.Map<MonthlyEmployee>(employeeInfo);
                default:
                    throw new EmployeeBusinessException("Unable to determine employee contract type.");
            }
        }
    }
}
