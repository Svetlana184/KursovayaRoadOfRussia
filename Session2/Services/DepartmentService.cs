using Desktop.Model;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services
{
    public class DepartmentService : BaseService<Department>
    {
        private HttpClient client;

        public DepartmentService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization",
                "Bearer" + RegisterUser.access_token);
        }

        public override async Task<bool> Add(Department obj)
        {
            await client.PostAsJsonAsync<Department>("https://localhost:7013/api/Departments/post", obj);
            return true;
        }

        public override async Task<bool> Delete(Department obj)
        {
            await client.DeleteFromJsonAsync<Department>($"https://localhost:7013/api/Departments/delete/{obj.IdDepartment}");
            return true;
        }

        public override async Task<List<Department>> GetAll()
        {
            List<Department>? deps = await client.GetFromJsonAsync<List<Department>>("https://localhost:7013/api/Departments/getall");
            return deps!;
        }

        public override async Task<bool> Update(Department obj)
        {
            await client.PutAsJsonAsync<Department>($"https://localhost:7013/api/Departments/update/{obj.IdDepartment}", obj);
            return true;
        }
    }
}
