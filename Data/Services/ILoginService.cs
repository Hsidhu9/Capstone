using ShiftPicker.Data.Models;

namespace ShiftPicker.Data.Services
{
    /// <summary>
    /// Abstraction of Login Service
    /// </summary>
    public interface ILoginService
    {
       LoginModel Authenticate(string userName, string password);

    }
}