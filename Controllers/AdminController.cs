using Microsoft.AspNetCore.Mvc;
using SilveOakDemo.Models;
using SilveOakDemo.Repo;
using System.Threading.Tasks;

namespace SilveOakDemo.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly ITaskServices _taskRepository;

        public AdminController(ITaskServices taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaskList()
        {
            return View();
        }

        [Route("getalltasks")]

        public async Task<JsonResult> GetallTasks()
        {
            ResponseModel res = new ResponseModel();
            res =await _taskRepository.GetAllTasks();
            return Json(res);
        }

        [Route("inserttask")]
        public async Task<JsonResult> InsertTask([FromBody] Tasks u)
        {
            ResponseModel res = new ResponseModel();
            res =await _taskRepository.CreateTask(u);
            return Json(res);
        }

        [Route("updatetask")]
        public async Task<JsonResult> UpdateTask([FromBody] Tasks u)
        {
            ResponseModel res = new ResponseModel();
            res =await _taskRepository.UpdateTask(u);
            return Json(res);
        }

        [Route("edittask")]
        public async Task<JsonResult> EditTask(int uid)
        {
            ResponseModel res = new ResponseModel();
            res =await _taskRepository.GetTaskById(uid);
            return Json(res);
        }

        [Route("deletetask")]
        public async Task<JsonResult> DeleteTask(int taskid)
        {
            ResponseModel res = new ResponseModel();
            res =await _taskRepository.DeleteTask(taskid);
            return Json(res);
        }

        [Route("mytask")]
        public IActionResult MyTask()
        {
            return View();
        }
    }
}
