namespace Employee_Management_System.Dtos
{
    public class ViewEmployeeDto
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string? Position { get; set; }

        public decimal Salary { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
