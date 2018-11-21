using System;
using AutoMapper;
using MasGlobal.Employees.Business.Model;
using Entity = MasGlobal.Employees.DataAccess.Model;

namespace MasGlobal.Employees.Business.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Entity.Employee, HourlyEmployee>()
                .AfterMap((entity, model) => model.ContractTypeDescription = entity.ContractTypeName)
                .AfterMap((entity, model) => model.Salary = entity.HourlySalary)
                .AfterMap((entity, model) => model.ContractType = Enum.Parse<ContractType>(entity.ContractTypeName));

            CreateMap<Entity.Employee, MonthlyEmployee>()
                .AfterMap((entity, model) => model.ContractTypeDescription = entity.ContractTypeName)
                .AfterMap((entity, model) => model.Salary = entity.MonthlySalary)
                .AfterMap((entity, model) => model.ContractType = Enum.Parse<ContractType>(entity.ContractTypeName));
        }
    }
}
