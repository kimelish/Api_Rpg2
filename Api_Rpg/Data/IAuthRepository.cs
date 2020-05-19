using System.Threading.Tasks;
using Api_Rpg.Models.User;
using Api_Rpg.Services;

namespace Api_Rpg.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);

        Task<ServiceResponse<string>> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}