namespace MasGlobal.Employees.Business.Model
{
    public class HourlyEmployee : Employee
    {
        public override int AnnualSalary => 120 * base.Salary * 12;
    }
}
