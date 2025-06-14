using Microsoft.AspNetCore.Mvc;
using SilveOakDemo.Models;
using SilveOakDemo.Repo;


namespace SilveOakDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userRepository;
        public UserController(IUserServices userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            GetallUsers();
            return View();
        }

        [Route("user/getalluser")]
        public JsonResult GetallUsers()
        {
            ResponseModel res = new ResponseModel();
            res= _userRepository.GetAllUsers();
            return Json(res);
        }

        [Route("user/insertuser")]
        public JsonResult InsertUser([FromBody] User u)
        {
            ResponseModel res = new ResponseModel();
            res = _userRepository.CreateUser(u);
            return Json(res);
        }

        [Route("user/updateuser")]
        public JsonResult UpdateUser([FromBody] User u)
        {
            ResponseModel res = new ResponseModel();
            res = _userRepository.UpdateUser(u);
            return Json(res);
        }

        [Route("user/edituser")]
        public JsonResult EditUser(int uid)
        {
            ResponseModel res = new ResponseModel();
            res = _userRepository.GetUserById(uid);
            return Json(res);
        }

        [Route("user/deleteuser")]
        public JsonResult DeleteUser(int uid)
        {
            ResponseModel res = new ResponseModel();
            res = _userRepository.DeleteUser(uid);
            return Json(res);
        }

        [Route("user/loginuser")]
        public JsonResult LoginUser(string email, string password)
        {
            ResponseModel res = new ResponseModel();
            res = _userRepository.LoginUser(email,password);
            return Json(res);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult MyTask()
        {
            return View();
        }

        [Route("user/getallmytasks")]
        public JsonResult GetallMyTasks(int id)
        {
            ResponseModel res = new ResponseModel();
            res = _userRepository.GetAllMyTasks(id);
            return Json(res);
        }


        [Route("user/updatetaskstatus")]
        public JsonResult UpdateTaskStatus(int id,string status)
        {
            ResponseModel res = new ResponseModel();
            res = _userRepository.UpdateTaskStatus(id,status);
            return Json(res);
        }
        
    }
}
