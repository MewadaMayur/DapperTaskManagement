using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SilveOakDemo.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;


namespace SilveOakDemo.Repo
{
    public class UserServices : IUserServices
    {

        private readonly IConfiguration _configuration;
        public UserServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ResponseModel GetAllUsers()
        {
            ResponseModel res = new ResponseModel();
            var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "select u.uid,u.uname,u.email,u.profilephoto,r.rolename from tbluser u join tblrole r on u.roleid = r.roleid";
            res.Data = con.Query(sql).ToList();
            if (res.Data != null)
            {
                res.Flag = false;
            }
            res.Flag = true;
            return res;
        }
        public ResponseModel GetUserById(int uid)
        {
            ResponseModel res = new ResponseModel();
            var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "select * from tbluser where uid = @uid";
            res.Data = con.QueryFirstOrDefault(sql, new { uid = uid });
            if (res.Data == null)
            {
                res.Flag = false;
                res.Message = "User not updated";
            }
            else
            {
                res.Flag = true;
                res.Message = "User updated successfully";
            }
                
            return res;
        }
        public ResponseModel CreateUser(User user)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                //check duicate user
                var checkUser = con.ExecuteScalar("SELECT count(uid) FROM tbluser WHERE email = @email", 
                    new { email = user.email });
                if (Convert.ToInt32(checkUser)>0)
                {
                    res.Flag = false;
                    res.Message = "User already exists";
                }
                else
                {
                    var sql = "INSERT INTO [dbo].[tbluser]([uname],[email],[pass],[roleid])" +
                   "VALUES(@uname,@email,@pass,@roleid)";
                    res.Data = con.Execute(sql, user);
                    if (res.Data == null || Convert.ToInt16(res.Data) == 0)
                    {
                        res.Flag = false;
                        res.Message = "User not created";
                    }
                    else
                    {
                        res.Flag = true;
                        res.Message = "User created successfully";
                    }
                    
                    
                }
                return res;
            }
            catch (Exception ex)
            {
                res.Flag = false;
                res.Message = "User not created";
            }

            return res;

        }
        public ResponseModel UpdateUser(User user)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                var checkUser = con.ExecuteScalar("SELECT count(uid) FROM tbluser WHERE email = @email and uid<>@uid",
                    new {email = user.email,uid=user.uid });
                if (Convert.ToInt32(checkUser) > 0)
                {
                    res.Flag = false;
                    res.Message = "User already exists with this email";
                    return res;
                }
                else
                {
                    var sql = "UPDATE [dbo].[tbluser] SET [uname] = @uname ,[email] =@email,[pass] =@pass,[profilephoto] ='',[roleid] = @roleid WHERE uid =@uid";
                    res.Data = con.Execute(sql, user);
                    if (res.Data == null || Convert.ToInt16(res.Data) == 0)
                    {
                        res.Flag = false;
                        res.Message = "User not updated";
                    }
                    res.Flag = true;
                    res.Message = "User updated successfully";

                }
            }
            catch (Exception ex)
            {
                res.Flag = false;
                res.Message = ex.Message;
            }

            return res;
        }
        public ResponseModel DeleteUser(int id)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var sql = "Delete from tbluser WHERE uid =@uid";
                res.Data = con.Execute(sql, new { uid = id });
                if (res.Data == null || Convert.ToInt16(res.Data) == 0)
                {
                    res.Flag = false;
                    res.Message = "User not deleted";
                }
                res.Flag = true;
                res.Message = "User deleted";

            }
            catch (Exception ex)
            {
                res.Flag = false;
                res.Message = ex.Message;
            }

            return res;
        }
        public ResponseModel LoginUser(string email, string password)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var sql = "select u.uid,u.uname,u.email,u.profilephoto,r.rolename from tbluser u join tblrole r on u.roleid = r.roleid where u.email = @email and u.pass=@pass";
                res.Data = con.QueryFirstOrDefault(sql, new { email = email,pass=password });
                if (res.Data ==null)
                {
                    res.Flag = false;
                    res.Message = "Login faild";
                }
                else
                {
                    res.Flag = true;
                    res.Message = "Login successfully";
                }
            }
            catch (Exception ex)
            {
                res.Flag = false;
                res.Message = ex.Message;
            }

            return res;
        }
        public ResponseModel GetAllMyTasks(int userid)
        {
                ResponseModel res = new ResponseModel();
            try
            {
                var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var sql = "select t.taskid,t.title,t.description,t.status,u.uname from tbltask t join tbluser u on t.assignedid = u.uid where t.assignedid= @userid";
                res.Data = con.Query(sql, new { userid = userid }).ToList();
                if (res.Data == null)
                {
                    res.Flag = false;
                }
                res.Flag = true;
                return res;

            }
            catch (Exception ex)
            {
                res.Flag = true;

                res.Message = ex.Message;
            }
            return res;
            
        }

        public ResponseModel UpdateTaskStatus(int taskid,string status)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var sql = "update tbltask set status = @status where taskid = @taskid";
                res.Data = con.Execute(sql, new {status= status , taskid = taskid });
                if (res.Data == null)
                {
                    res.Flag = false;
                    res.Message = "Task status not updated";
                }
                else
                {
                    res.Flag = true;
                    res.Message = "Task status updated successfully";
                }
                
                return res;

            }
            catch (Exception ex)
            {
                res.Flag = true;

                res.Message = ex.Message;
            }
            return res;

        }

    }
}
