using Session2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Services
{
    public class EmployeeService : BaseService<Employee>
    {
        private HttpClient client;
        public override async Task<bool> Add(Employee obj)
        {
            client = new HttpClient();
            await client.PostAsJsonAsync<Employee>("https://localhost:7013/api/Employee/post", obj);
            return true;
        }

        public override async Task<bool> Delete(Employee obj)
        {
            client = new HttpClient();
            await client.DeleteFromJsonAsync<Employee>($"https://localhost:7013/api/Employee/update/{obj.IdEmployee}");
            return true;
        }

        public override async Task<List<Employee>> GetAll()
        {
            client = new HttpClient();
            List<Employee>? emps = await client.GetFromJsonAsync<List<Employee>>("https://localhost:7013/api/Employee/getall");
            return emps!;

        }

        public override async Task<bool> Update(Employee obj)
        {
            client = new HttpClient();
            await client.PutAsJsonAsync<Employee>($"https://localhost:7013/api/Employee/update/{obj.IdEmployee}", obj);
            return true;
        }
    }
}
