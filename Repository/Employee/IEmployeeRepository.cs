using Employee_Management_System.Dtos;

namespace Employee_Management_System.Repository.Employee
{
    public interface IEmployeeRepository
    {
       Task<bool> AddEmployeeAsync(EmployeeDto employeeDto);
       Task<bool> EditEmployeeAsync(int employeeId ,EmployeeDto employeeDto);
       Task<bool> DeleteEmployeeAsync(int employeeId);
       Task<ViewEmployeeDto?> GetEmployeeByIdAsync(int employeeId);
       Task<IEnumerable<ViewEmployeeDto?>> GetAllEmployeesAsync(); 
    }
}
