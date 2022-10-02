using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.API.Base;
using TaskManagement.API.DataLayer.Entities;
using TaskManagement.API.DataLayer.Repositories;
using TaskManagement.API.Models.Request;
using TaskManagement.API.Models.Response;

namespace TaskManagement.API.ServiceLayer
{
    public interface ITaskService
    {

        Task<BaseResponse<List<ResponseTask>>> GetAllAsync();
        Task<BaseResponse<bool>> CreateAsync(RequestTask request);
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
        public async Task<BaseResponse<bool>> CreateAsync(RequestTask request)
        {
            var response = new BaseResponse<bool>();

            var model = new TMTask(request.TaskDescription);

            if (!string.IsNullOrEmpty(request.AssignedTo))
            {
                model.AddAssignedTo(model.AssignedTo);
            }

            if (request.NextActionDate.HasValue)
            {
                model.AddNextActionDate(request.NextActionDate.Value);
            }
            
            if (request.StatusOfTask.HasValue)
            {
                model.AddStatusOfTask(request.StatusOfTask.Value);
            }
            
            if (request.TypeOfTask.HasValue)
            {
                model.AddTypeOfTask(request.TypeOfTask.Value);
            }

            await _taskRepository.CreateAsync(model);
            
            return response.SetData(true);
        }
    }
}
