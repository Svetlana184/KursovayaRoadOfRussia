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
    public class DepartmentService : BaseService<Department>
    {
        private HttpClient client;
        public override bool Add(Department obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Departments.Add(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override bool Delete(Department obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Departments.Remove(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override async Task<List<Department>> GetAll()
        {
            client = new HttpClient();
            List<Department>? deps = await client.GetFromJsonAsync<List<Department>>("https://localhost:7013/api/Departments/getall");
            return deps!;
        }

        public override bool Update(Department obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Departments.Update(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
    }
}
