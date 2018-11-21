namespace MasGlobal.Employees.Business.Model
{
    public abstract class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ContractType ContractType { get; set; }

        public string ContractTypeDescription { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public double RoleDescription { get; set; }

        public double Salary { get; set; }

        public virtual double AnnualSalary { get; }
    }
}
