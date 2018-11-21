namespace MasGlobal.Employees.Business.Model
{
    public class MonthlyEmployee: Employee
    {
        public override int AnnualSalary => base.Salary * 12;
    }
}
