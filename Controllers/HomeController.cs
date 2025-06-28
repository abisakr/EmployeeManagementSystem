using System.Diagnostics;
using Employee_Management_System.Models;
using Employee_Management_System.Repository.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;

        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var email = Request.Cookies["Email"];
                if (string.IsNullOrEmpty(email))
                {
                    return RedirectToAction("Login", "Authentication");
                }
                var result = await _employeeRepository.GetAllEmployeesAsync(); //fetched all  employee details
                if (result != null) // if not null return view with details 
                {
                    return View(result);
                }
                return View();// return view with empty list if the list is null
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error on Loading UserPage with EmployeeData:{ex.Message}.";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
