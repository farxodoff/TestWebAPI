namespace TestWebAPI.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal Salary { get; set; }

        // Foreign key Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // Foreign key Role
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
