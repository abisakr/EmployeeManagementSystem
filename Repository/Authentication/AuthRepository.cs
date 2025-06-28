using Employee_Management_System.Dtos;
using Employee_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Repository.Authentication
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EmployeeManagementDbContext _context;
        public AuthRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUser(UserRegisterDto userRegisterDto)
        {
            var passwordHasher = new PasswordHasher<object>(); //used identity to hash the password
            string hashedPassword = passwordHasher.HashPassword(null, userRegisterDto.Password);
            // Hash the password to save in database for safety
            var result = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC spUserRegisteration {userRegisterDto.UserName}, {userRegisterDto.Email}, {hashedPassword}"
            );
            return result > 0;//if true user created if false fail due to dupllication
        }

        public async Task<bool> UserLogin(UserLoginDto userLoginDto)
        {
             var getPaswword = await _context.UsersDbs.FromSqlInterpolated($"EXEC spUserLogin {userLoginDto.Email}")
                .AsNoTracking().ToListAsync();//because FromAqlInterpolated returns the IQuarable lists
              var storedHashedPassword = getPaswword.Select(x => x.PasswordHash).FirstOrDefault(); //get the first password hash from the list

            if (storedHashedPassword != null)
            {
                PasswordHasher<object> passwordHasher = new PasswordHasher<object>();
                var verificationResult = passwordHasher.VerifyHashedPassword(null, storedHashedPassword, userLoginDto.Password);
                if (verificationResult == PasswordVerificationResult.Success)
                {
                    return true;
                }
                return false;
            }
            return false; //return invalid username or password giving 0 as return 
        }
    }

}
