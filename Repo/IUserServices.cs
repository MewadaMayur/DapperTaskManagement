using SilveOakDemo.Models;

namespace SilveOakDemo.Repo
{
    public interface IUserServices
    {
        Task<ResponseModel> GetUserById(int id);
        Task<ResponseModel> GetAllUsers();
        Task<ResponseModel> CreateUser(User user);
        Task<ResponseModel> UpdateUser(User user);
        Task<ResponseModel> DeleteUser(int id);
        Task<ResponseModel> LoginUser(string email, string password);
        Task<ResponseModel> GetAllMyTasks(int userid);
        Task<ResponseModel> UpdateTaskStatus(int userid, string status);
    }
}
