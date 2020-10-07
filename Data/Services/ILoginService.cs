using ShiftPicker.Data.Models;

namespace ShiftPicker.Data.Services
{
    public interface ILoginService
    {
        bool Authenticate(LoginModel loginModel);

    }
}