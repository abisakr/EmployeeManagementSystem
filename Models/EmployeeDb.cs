using System;
using System.Collections.Generic;

namespace Employee_Management_System.Models;

public partial class EmployeeDb
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } 

    public string Email { get; set; }

    public string Address { get; set; } 

    public string Department { get; set; } 

    public string? Position { get; set; }

    public decimal Salary { get; set; }

    public DateTime? CreatedAt { get; set; }
}
