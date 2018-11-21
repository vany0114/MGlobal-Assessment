using AutoMapper;
using MasGlobal.Employees.Business.Model;
using Entity = MasGlobal.Employees.DataAccess.Model;

namespace MasGlobal.Employees.Business.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Entity.Employee, HourlyEmployee>();
            CreateMap<Entity.Employee, MonthlyEmployee>();
        }
    }
}
