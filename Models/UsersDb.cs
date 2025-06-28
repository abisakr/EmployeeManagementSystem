using System;
using System.Collections.Generic;

namespace Employee_Management_System.Models;

public partial class UsersDb
{
    public int UserId { get; set; }

    public string UserName { get; set; } 

    public string Email { get; set; }

    public string? PasswordHash { get; set; }

    public string Role { get; set; }

    public DateTime CreatedAt { get; set; }
}
