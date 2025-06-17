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
    public class TaskServices : ITaskServices
    {

        private readonly IConfiguration _configuration;
        
        public TaskServices(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public async Task<ResponseModel> GetAllTasks()
        {
            ResponseModel res = new ResponseModel();
            var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "select taskid,title,description,status,u.uname from tbltask t join tbluser u on t.assignedid = u.uid";
            res.Data =await con.QueryAsync(sql);
            if (res.Data == null)
            {
                res.Flag = false;
            }
            res.Flag = true;
            return res;
        }
        public async Task<ResponseModel> GetTaskById(int id)
        {
            ResponseModel res = new ResponseModel();
            var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = "select * from tbltask where taskid = @taskid";
            res.Data =await con.QueryFirstOrDefaultAsync(sql, new { taskid = id });
            if (res.Data == null)
            {
                res.Flag = false;
                res.Message = "Task not updated";
            }
            else
            {
                res.Flag = true;
                res.Message = "Task updated successfully";
            }
                
            return res;
        }
        public async Task<ResponseModel> CreateTask(Tasks Task)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                
                
                //check duicate Task
                    var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var checkTask =await con.ExecuteScalarAsync("SELECT count(taskid) FROM tbltask WHERE title = @title", 
                    new { title = Task.title });
                if (Convert.ToInt32(checkTask)>0)
                {
                    res.Flag = false;
                    res.Message = "Task already exists";
                }
                else
                {
                    var sql = "INSERT INTO [dbo].[tbltask]([title],[description],[status],[assignedid])" +
                   "VALUES(@title,@description,@status,@assignedid)";
                    res.Data = con.Execute(sql, Task);
                    if (res.Data == null || Convert.ToInt16(res.Data) == 0)
                    {
                        res.Flag = false;
                        res.Message = "Task not created";
                    }
                    else
                    {
                        res.Flag = true;
                        res.Message = "Task created successfully";
                    }
                    
                    
                }
                return res;
            }
            catch (Exception ex)
            {
                res.Flag = false;
                res.Message = "Task not created";
            }

            return res;

        }
        public async Task<ResponseModel> UpdateTask(Tasks Task)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                var checkTask =await con.ExecuteScalarAsync("SELECT count(taskid) FROM tbltask WHERE title = @title and taskid<>@taskid",
                    new {title = Task.title, taskid = Task.taskid});
                if (Convert.ToInt32(checkTask) > 0)
                {
                    res.Flag = false;
                    res.Message = "Task already exists with this title";
                    return res;
                }
                else
                {
                    var sql = "UPDATE [dbo].[tbltask] SET [title] = @title,[description] =@description,[status] =@status," +
                        "[assignedid] = @assignedid WHERE taskid =@taskid";
                    res.Data = con.Execute(sql, Task);
                    if (res.Data == null || Convert.ToInt16(res.Data) == 0)
                    {
                        res.Flag = false;
                        res.Message = "Task not updated";
                    }
                    res.Flag = true;
                    res.Message = "Task updated successfully";

                }
            }
            catch (Exception ex)
            {
                res.Flag = false;
                res.Message = ex.Message;
            }

            return res;
        }
        public async Task<ResponseModel> DeleteTask(int id)
        {
            ResponseModel res = new ResponseModel();
            try
            {
                var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var sql = "Delete from tbltask WHERE taskid =@taskid";
                res.Data =await con.ExecuteAsync(sql, new { taskid = id });
                if (res.Data == null || Convert.ToInt16(res.Data) == 0)
                {
                    res.Flag = false;
                    res.Message = "Task not deleted";
                }
                res.Flag = true;
                res.Message = "Task deleted";

            }
            catch (Exception ex)
            {
                res.Flag = false;
                res.Message = ex.Message;
            }

            return res;
        }
   
    }
}
