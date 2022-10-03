using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StronglyTypedHttpClient.Models
{
    public interface ITodoService
    {
        Task<List<ToDo>> GetAllAsync();
        Task<ToDo> GetTodoAsync(int id);
        Task<ToDo> CreateTodoAsync(ToDo task);
        Task<ToDo> UpdateTodoAsync(ToDo task);
        Task DeleteTodoAsync(int id);
    }
}
