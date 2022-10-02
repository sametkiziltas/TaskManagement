using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.Base;
using TaskManagement.API.DataLayer.Entities;
using TaskManagement.API.Models.Request;
using TaskManagement.API.Models.Response;
using TaskManagement.API.ServiceLayer;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet("/tasks")]
        [ProducesResponseType(typeof(BaseResponse<List<ResponseTask>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBackLogItems()
        {
            var response = await _taskService.GetAllAsync();

            if (!response.IsSuccess)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Data);
        }
        
        [HttpPost("/tasks")]
        [ProducesResponseType(typeof(BaseResponse<ResponseTask>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTask(RequestTask request)
        {
            var response = await _taskService.CreateAsync(request);

            if (!response.IsSuccess)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Data);
        }
        
        [HttpPut("/tasks")]
        [ProducesResponseType(typeof(BaseResponse<List<ResponseTask>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTask()
        {
            var response = await _taskService.GetAllAsync();

            if (!response.IsSuccess)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Data);
        }
    }
}
