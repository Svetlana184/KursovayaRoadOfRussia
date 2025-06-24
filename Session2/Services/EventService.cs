using Session2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Services
{
    public class EventService : BaseService<Event>
    {
        public override bool Add(Event obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Events.Add(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override bool Delete(Event obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Events.Remove(obj);
                db.SaveChangesAsync();
            }
            return true;
        }

        public override List<Event> GetAll()
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                return db.Events.ToList();
            }
        }

        public override bool Update(Event obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                db.Events.Update(obj);
                db.SaveChangesAsync();
            }
            return true;
        }
    }
}
