using Employee_Management_System.Dtos;
using Employee_Management_System.Repository.Authentication;
using Employee_Management_System.Repository.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthRepository _authRepository;

        public AuthenticationController(IAuthRepository authRepository)//dependency injection
        {
            _authRepository = authRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Return view with validation messages if model is invalid
                    return View(userRegisterDto);
                }
                bool result = await _authRepository.RegisterUser(userRegisterDto);
                if (result)
                {
                    TempData["Success"] = "Registered successfully!"; 
                    return RedirectToAction("Login");
                }
                TempData["Error"] = "Failed to register:User or Email may already exists.";
                return View(userRegisterDto);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error on Register:{ex.Message}.";
                return View(userRegisterDto);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                // Return view with validation messages if model is invalid
                    return View(userLoginDto);
                }
          
                bool result = await _authRepository.UserLogin(userLoginDto);
                if (result)
                {
                    var cookieOptions = new CookieOptions //cookies to store user email
                    {
                        Expires = DateTime.Now.AddDays(5),
                        Path = "/"
                    };
                    Response.Cookies.Append("Email", userLoginDto.Email, cookieOptions);
                    TempData["Success"] = "Logged in successfully!";
                    return RedirectToAction("Index", "Home");
                }
                TempData["Error"] = "Invalid email or password. Please try again.";
                return View(userLoginDto);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error on Login:{ex.Message}.";
                return View(userLoginDto);
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("Email");
            TempData["success"] = "Logged out successfully!";   
            return RedirectToAction("Login");   
        }

    }
}
