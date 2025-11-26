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
    public class EmployeeService : BaseService<Employee>
    {
        private HttpClient client;

        public EmployeeService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization",
                "Bearer" + RegisterUser.access_token);
        }
        public override Task<List<Employee>> Search(string str)
        {
            throw new NotImplementedException();
        }
        public override async Task<bool> Add(Employee obj)
        {
           
            await client.PostAsJsonAsync<Employee>("https://localhost:7013/api/Employee/post", obj);
            return true;
        }

        public override async Task<bool> Delete(Employee obj)
        {
            
            await client.DeleteFromJsonAsync<Employee>($"https://localhost:7013/api/Employee/update/{obj.IdEmployee}");
            return true;
        }

        public override async Task<List<Employee>> GetAll()
        {
           
            List<Employee>? emps = await client.GetFromJsonAsync<List<Employee>>("https://localhost:7013/api/Employee/getall");
            return emps!;

        }

        public override async Task<bool> Update(Employee obj)
        {
            
            await client.PutAsJsonAsync<Employee>($"https://localhost:7013/api/Employee/update/{obj.IdEmployee}", obj);
            return true;
        }
    }
}
