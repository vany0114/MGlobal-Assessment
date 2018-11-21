namespace MasGlobal.Employees.Business.Model
{
    public abstract class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ContractType ContractType { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public object RoleDescription { get; set; }

        public int Salary { get; set; }

        public virtual int AnnualSalary { get; }
    }
}
