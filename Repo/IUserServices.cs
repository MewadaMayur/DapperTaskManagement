using SilveOakDemo.Models;

namespace SilveOakDemo.Repo
{
    public interface IUserServices
    {
         ResponseModel GetUserById(int id);
         ResponseModel GetAllUsers();
         ResponseModel CreateUser(User user);
         ResponseModel UpdateUser(User user);
         ResponseModel DeleteUser(int id);
        ResponseModel LoginUser(string email, string password);

        ResponseModel GetAllMyTasks(int userid);

        ResponseModel UpdateTaskStatus(int userid,string status);
    }
}
