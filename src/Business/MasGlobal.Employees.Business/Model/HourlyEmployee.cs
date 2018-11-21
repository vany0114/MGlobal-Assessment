namespace MasGlobal.Employees.Business.Model
{
    public class HourlyEmployee : Employee
    {
        // TODO: consider making these constants configurable.

        public override double AnnualSalary => 120 * base.Salary * 12;
    }
}
