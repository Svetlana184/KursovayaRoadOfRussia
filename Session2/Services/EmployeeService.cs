using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session2.Model;

namespace Session2.Services
{
    public class EmployeeService : BaseService<Employee>
    {

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

        public override List<Employee> GetAll()
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                return db.Employees.ToList();
            }
            
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
