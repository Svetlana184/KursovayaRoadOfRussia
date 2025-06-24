using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session2.Model;

namespace Session2.Services
{
    public class CalendarService : BaseService<Calendar_>
    {
        public override bool Add(Calendar_ obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Calendars.Add(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override bool Delete(Calendar_ obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Calendars.Remove(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override List<Calendar_> GetAll()
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                return db.Calendars.ToList();
            }
        }

        public override bool Update(Calendar_ obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Calendars.Update(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
    }
}
