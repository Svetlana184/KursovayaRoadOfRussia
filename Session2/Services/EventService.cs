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
    public class EventService : BaseService<Event>
    {
        private HttpClient client;
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

        public override async Task<List<Event>> GetAll()
        {
            client = new HttpClient();
            List<Event>? evs = await client.GetFromJsonAsync<List<Event>>("https://localhost:7013/api/Event/getall");
            return evs!;
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
