namespace PPM.Model
{
    public class Project
    {
        public int projectId { get; set; }
        public string? projectName { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
        public List<Employee> employeesProject { get; set; } = new List<Employee>();

    }
}
