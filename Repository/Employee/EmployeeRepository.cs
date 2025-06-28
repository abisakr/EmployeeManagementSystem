using Employee_Management_System.Dtos;
using Employee_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Repository.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementDbContext _context;
        public EmployeeRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var result = await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC spAddEmployee {employeeDto.EmployeeName}, {employeeDto.Email}, {employeeDto.Address}, {employeeDto.Department}, {employeeDto.Position}, {employeeDto.Salary}"
              );
            return result > 0;
        }
        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var checkEmployee = await GetEmployeeByIdAsync(employeeId);
            if (checkEmployee == null)
                return false;
            var employee = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC spDeleteEmployee {employeeId}");
            return employee > 0;
        }

        public async Task<bool> EditEmployeeAsync(int employeeId, EmployeeDto employeeDto)
        {
            var checkEmployee = await GetEmployeeByIdAsync(employeeId);
            if (checkEmployee == null)
                return false;

            var employee = await _context.Database.ExecuteSqlInterpolatedAsync(
             $"EXEC spEditEmployee {employeeId}, {employeeDto.EmployeeName}, {employeeDto.Email}, {employeeDto.Address}, {employeeDto.Department}, {employeeDto.Position}, {employeeDto.Salary}"
             );
            return employee > 0;
        }

        public async Task<IEnumerable<ViewEmployeeDto?>> GetAllEmployeesAsync()
        {
            var employees = await _context.EmployeeDbs
                .FromSqlInterpolated($"EXEC spGetAllEmployee")
                .AsNoTracking()
                .ToListAsync();

            return employees.Select(e => new ViewEmployeeDto
            {
                EmployeeId = e.EmployeeId,
                EmployeeName = e.EmployeeName,
                Email = e.Email,
                Address = e.Address,
                Department = e.Department,
                Position = e.Position,
                Salary = e.Salary,
                CreatedAt = e.CreatedAt
            });
        }


        public async Task<ViewEmployeeDto?> GetEmployeeByIdAsync(int employeeId)
        {
            var employees =await  _context.EmployeeDbs
                .FromSqlInterpolated($"EXEC spGetEmployeeById {employeeId}")
                .AsNoTracking()
                .ToListAsync();

            var employee = employees.Select(e => new ViewEmployeeDto
            {
                EmployeeId = e.EmployeeId,
                EmployeeName = e.EmployeeName,
                Email = e.Email,
                Address = e.Address,
                Department = e.Department,
                Position = e.Position,
                Salary = e.Salary,
                CreatedAt = e.CreatedAt
            }).FirstOrDefault();

            return employee;
        }
    }
}
