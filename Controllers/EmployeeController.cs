using System.Threading.Tasks;
using Employee_Management_System.Dtos;
using Employee_Management_System.Models;
using Employee_Management_System.Repository.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)//dependency injection
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult AddEmployee()
        {
                var email = Request.Cookies["Email"];
                if (string.IsNullOrEmpty(email))
                {
                    TempData["Error"] = "Please log in to access this page.";
                    return RedirectToAction("Login", "Authentication");
                }
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Return view with validation messages if model is invalid
                    return View(employeeDto);
                }
                bool result = await _employeeRepository.AddEmployeeAsync(employeeDto);
                if (result)
                {
                    TempData["Success"] = "Employee added successfully!";
                    return RedirectToAction("Index", "Home");
                }
                TempData["Error"] = "Failed to add employee. Please try again.";
                return View(employeeDto);

            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error on Adding Employee:{ex.Message}.";
                return View(employeeDto);
            }
        }

        public async Task<IActionResult>  EditEmployee(int id)
        {
            try
            {
                var email = Request.Cookies["Email"];
                if (string.IsNullOrEmpty(email))
                {
                    TempData["Error"] = "Please log in to access this page.";
                    return RedirectToAction("Login", "Authentication");
                }
                var result = await _employeeRepository.GetEmployeeByIdAsync(id);
                if (result != null)
                {
                    return View(result);
                }
                TempData["Error"] = "Failed to Load employee Details. Please try again.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error on Loading EditPage with Data :{ex.Message}.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(int id,EmployeeDto employeeDto)
        {
            try
            {
                var dto = new ViewEmployeeDto
                {
                    EmployeeId = id,
                    EmployeeName = employeeDto.EmployeeName,
                    Email = employeeDto.Email,
                    Address = employeeDto.Address,
                    Department = employeeDto.Department,
                    Position = employeeDto.Position,
                    Salary = employeeDto.Salary
                };
                if (!ModelState.IsValid)
                {
                    // Return view with validation messages if model is invalid
                    return View(dto);
                }

                bool result = await _employeeRepository.EditEmployeeAsync(id, employeeDto);
                if (result)
                {
                    TempData["Success"] = "Employee Edited successfully!";
                    return RedirectToAction("Index", "Home");
                }
                TempData["Error"] = "Failed to Edit employee. Please try again.";
                return View(employeeDto); //returned in edit employee view with entered data 
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error on Editing:{ex.Message}.";
                return View(employeeDto);
            }
        }

        public async Task<IActionResult>  DeleteEmployee(int id)
        {
            try
            {
                var email = Request.Cookies["Email"];
                if (string.IsNullOrEmpty(email))
                {
                    TempData["Error"] = "Please log in to access this page.";
                    return RedirectToAction("Login", "Authentication");
                }
                bool result = await _employeeRepository.DeleteEmployeeAsync(id);
                if (result)
                {
                    TempData["Success"] = "Employee Deleted successfully!";
                    return RedirectToAction("Index", "Home");
                }
                TempData["Error"] = "Failed to Delete employee. Please try again.";
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error on Deleting:{ex.Message}.";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}