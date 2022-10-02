using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Base;
using TaskManagement.API.DataLayer.Entities;

namespace TaskManagement.API.DataLayer.Repositories
{
    public interface ITaskRepository
    {

        Task<List<TMTask>> GetAllAsync();
        Task CreateAsync(TMTask model);
    }

    public class TaskRepository : ITaskRepository
    {
        private readonly TMContext _context;

        public TaskRepository(TMContext context)
        {
            _context = context;
        }

        public async Task<List<TMTask>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }
        public async Task CreateAsync(TMTask model)
        {
            await _context.Tasks.AddAsync(model);
            await _context.SaveChangesAsync();
        }
    }
}
