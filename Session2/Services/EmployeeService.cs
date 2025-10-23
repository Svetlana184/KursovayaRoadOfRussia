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
        public override bool Add(Employee obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Employees.Add(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override bool Delete(Employee obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Employees.Remove(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override async Task<List<Employee>> GetAll()
        {
            client = new HttpClient();
            List<Employee>? emps = await client.GetFromJsonAsync<List<Employee>>("https://localhost:7013/api/Employee/getall");
            return emps!;

        }

        public override bool Update(Employee obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Employees.Update(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
    }
}
