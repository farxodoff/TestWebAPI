namespace TestWebAPI.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key References
        public ICollection<Employee> Employees { get; set; }
    }
}
