using Session2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Services
{
    public class DepartmentService : BaseService<Department>
    {
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

        public override List<Department> GetAll()
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                return db.Departments.ToList();
            }
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
