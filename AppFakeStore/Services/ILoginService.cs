using AppFakeStore.Models;
using System.Threading.Tasks;

namespace AppFakeStore.Services
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(string username, string password);
    }
}
