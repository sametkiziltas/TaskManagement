using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.API.Base;
using TaskManagement.API.DataLayer.Entities;
using TaskManagement.API.DataLayer.Repositories;
using TaskManagement.API.Models.Response;

namespace TaskManagement.API.ServiceLayer
{
    public interface ITaskService
    {

        Task<BaseResponse<List<ResponseTask>>> GetAllAsync();
    }
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        
        public async Task<BaseResponse<List<ResponseTask>>> GetAllAsync()
        {
            var response = new BaseResponse<List<ResponseTask>>();
            
            var returnList =  await _taskRepository.GetAllAsync();

            return response
                .SetData(returnList
                    .Select(x => new ResponseTask()
                    {
                        TaskDescription = x.TaskDescription,
                        CreatedDate = x.CreatedDate.ToString(CultureInfo.InvariantCulture),
                        StatusOfTask =  Enum.GetName(typeof(StatusOfTask), x.StatusOfTask),
                        TypeOfTask =  Enum.GetName(typeof(TypeOfTask), x.TypeOfTask),
                    })
                .ToList());
        }
    }
}
