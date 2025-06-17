using SilveOakDemo.Models;

namespace SilveOakDemo.Repo
{
    public interface ITaskServices
    {

        //ResponseModel GetAllTasks();
        Task<ResponseModel> GetAllTasks();
        Task<ResponseModel> GetTaskById(int uid);
        Task<ResponseModel> CreateTask(Tasks Task);
        Task<ResponseModel> UpdateTask(Tasks task);
        Task<ResponseModel> DeleteTask(int uid);
    }
}
