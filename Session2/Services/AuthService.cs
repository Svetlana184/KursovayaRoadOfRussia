using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Session2.Model;

namespace Desktop.Services
{
    public class AuthService
    {
        private HttpClient client = new HttpClient();
        public async Task<string> Register(Employee employee)
        {
            JsonContent content = JsonContent.Create(employee);
            using var response = await client.PostAsync("http://localhost:7229/register", content);
            string responseText = await response.Content.ReadAsStringAsync();
            if (responseText != "")
            {
                Response resp = JsonSerializer.Deserialize<Response>(responseText)!;
                return $"Пользователь {employee.Email} успешно создан";
            }
            return $"Пользователь {employee.Email} существует!";
        }
    }
}
