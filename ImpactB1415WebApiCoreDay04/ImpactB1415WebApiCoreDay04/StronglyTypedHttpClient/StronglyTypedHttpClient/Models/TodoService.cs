using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StronglyTypedHttpClient.Models
{
    public class TodoService:ITodoService
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/todos/";
        private readonly HttpClient _client;

        public TodoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<ToDo>>(content);

            return tasks;
        }

        public async Task<ToDo> GetTodoAsync(int id)
        {
            var httpResponse = await _client.GetAsync($"{BaseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var todoItem = JsonConvert.DeserializeObject<ToDo>(content);

            return todoItem;
        }

        public async Task<ToDo> CreateTodoAsync(ToDo task)
        {
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot add a todo task");
            }

            var createdTask = JsonConvert.DeserializeObject<ToDo>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task<ToDo> UpdateTodoAsync(ToDo task)
        {
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PutAsync($"{BaseUrl}{task.Id}", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update todo task");
            }

            var createdTask = JsonConvert.DeserializeObject<ToDo>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task DeleteTodoAsync(int id)
        {
            var httpResponse = await _client.DeleteAsync($"{BaseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the todo item");
            }
        }
    }
}
