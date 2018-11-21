namespace MasGlobal.Employees.Business.Model
{
    public class MonthlyEmployee: Employee
    {
        public override double AnnualSalary => base.Salary * 12;
    }
}
