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
    public class CalendarService : BaseService<Calendar_>
    {
        private HttpClient client;
        public override bool Add(Calendar_ obj)
        {
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                client = new HttpClient();
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

        public override async Task<List<Calendar_>> GetAll()
        {
            client = new HttpClient();
            List<Calendar_>? calendars = await client.GetFromJsonAsync<List<Calendar_>>("https://localhost:7013/api/Calendar/getall");
            return calendars!;
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
