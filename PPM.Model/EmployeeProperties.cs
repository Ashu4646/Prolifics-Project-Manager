namespace PPM.Model
{

    public class Employee
    {
        public int employeeId { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? mobileNumber { get; set; }
        public string? address { get; set; }
        public int roleId { get; set; }
        public bool deleted { get; set; }

    }
}