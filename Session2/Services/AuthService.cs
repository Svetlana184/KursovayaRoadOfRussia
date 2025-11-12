using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Desktop.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop.Services
{
    public class AuthService
    {
        private HttpClient client = new HttpClient();
        public async Task<String> Register(Employee employee)
        {
            JsonContent content = JsonContent.Create(employee);
            using var response = await client.PostAsync("https://localhost:7013/register", content);
            string responseText = await response.Content.ReadAsStringAsync();
            if (responseText != "")
            {
                return $"Пользователь {employee.Email} успешно создан";
            }
            return $"Пользователь {employee.Email} существует!";
        }
        public async Task<Response> SignIn(Employee employee)
        {
            JsonContent content = JsonContent.Create(employee);
            using var response = await client.PostAsync("https://localhost:7013/login", content);
            string responseText = await response.Content.ReadAsStringAsync();
            if (responseText != "")
            {
                Response resp = JsonSerializer.Deserialize<Response>(responseText)!;
                return resp;
            }
            return null!;
        }
    }
}
