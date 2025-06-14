using SilveOakDemo.Models;

namespace SilveOakDemo.Repo
{
    public interface ITaskServices
    {

        ResponseModel GetAllTasks();
        ResponseModel GetTaskById(int uid);
        ResponseModel CreateTask(Tasks Task);
        ResponseModel UpdateTask(Tasks task);
        ResponseModel DeleteTask(int uid);
    }
}
