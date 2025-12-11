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
    public class DepartmentService : BaseService<Department>
    {
        private HttpClient client;

        public DepartmentService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization",
               "Bearer " + RegisterUser.access_token);
        }

        public override Task<List<Department>> Search(string str)
        {
            throw new NotImplementedException();
        }
        public override async Task<bool> Add(Department obj)
        {

            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await client.PostAsync("https://localhost:7013/api/Departments/post", content);
                string responseText = await response.Content.ReadAsStringAsync();
                if (responseText != null)
                {
                    Department resp = JsonSerializer.Deserialize<Department>(responseText!)!;
                    if (resp == null) MessageBox.Show(responseText);
                }
            }
            catch { }
            return true;
        }

        public override async Task<bool> Delete(Department obj)
        {

            using var response = await client.DeleteAsync($"https://localhost:7013/api/Departments/delete/{obj.IdDepartment}");
            return true;
        }

        public override async Task<List<Department>> GetAll()
        {

            return (await client.GetFromJsonAsync<List<Department>>("https://localhost:7013/api/Departments/getall"))!; ;
        }

        public override async Task<bool> Update(Department obj)
        {

            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await client.PutAsync($"https://localhost:7013/api/Departments/update/{obj.IdDepartment}", content);
                string responseText = await response.Content.ReadAsStringAsync();
                if (responseText != null)
                {
                    Department resp = JsonSerializer.Deserialize<Department>(responseText!)!;
                    if (resp == null) MessageBox.Show(responseText);
                }

            }
            catch { }
            return true;
        }
    }
}
