using Employee_Management_System.Dtos;

namespace Employee_Management_System.Repository.Authentication
{
    public interface IAuthRepository
    {
        Task<bool> RegisterUser(UserRegisterDto userRegisterDto);   
        Task<bool> UserLogin(UserLoginDto userLoginDto);
    }
}
