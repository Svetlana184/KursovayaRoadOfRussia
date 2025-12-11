using Desktop.Model;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop.Services
{
    public class EmployeeService : BaseService<Employee>
    {
        private HttpClient client;

        public EmployeeService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization",
               "Bearer " + RegisterUser.access_token);
        }
        public override Task<List<Employee>> Search(string str)
        {
            throw new NotImplementedException();
        }
        public override async Task<bool> Add(Employee obj)
        {
            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await client.PostAsync("https://localhost:7013/api/Employee/post", content);
                string responseText = await response.Content.ReadAsStringAsync();
                if (responseText != null)
                {
                    Employee resp = JsonSerializer.Deserialize<Employee>(responseText!)!;
                    if (resp == null) MessageBox.Show(responseText);
                }
            }
            catch { }
            return true;
            
        }

        public override async Task<bool> Delete(Employee obj)
        {

            using var response = await client.DeleteAsync($"https://localhost:7013/api/Employee/delete/{obj.IdEmployee}");
            return true;
        }

        public override async Task<List<Employee>> GetAll()
        {
           
            List<Employee>? emps = await client.GetFromJsonAsync<List<Employee>>("https://localhost:7013/api/Employee/getall");
            return emps!;

        }

        public override async Task<bool> Update(Employee obj)
        {

            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await client.PutAsync($"https://localhost:7013/api/Employee/update/{obj.IdEmployee}", content);
                string responseText = await response.Content.ReadAsStringAsync();
                if (responseText != null)
                {
                    Employee resp = JsonSerializer.Deserialize<Employee>(responseText!)!;
                    if (resp == null) MessageBox.Show(responseText);
                }

            }
            catch { }
            return true;
        }
    }
}
