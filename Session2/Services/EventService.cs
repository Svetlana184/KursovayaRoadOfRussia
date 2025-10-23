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
        public override async Task<bool> Add(Event obj)
        {
            client = new HttpClient();
            await client.PostAsJsonAsync<Event>("https://localhost:7013/api/Event/post", obj);
            return true;
        }

        public override async Task<bool> Delete(Event obj)
        {
            client = new HttpClient();
            await client.DeleteFromJsonAsync<Event>($"https://localhost:7013/api/Event/delete/{obj.IdEvent}");
            return true;
        }

        public override async Task<List<Event>> GetAll()
        {
            client = new HttpClient();
            List<Event>? evs = await client.GetFromJsonAsync<List<Event>>("https://localhost:7013/api/Event/getall");
            return evs!;
        }

        public override async Task<bool> Update(Event obj)
        {
            client = new HttpClient();
            await client.PutAsJsonAsync<Event>($"https://localhost:7013/api/Event/update/{obj.IdEvent}", obj);
            return true;
        }
    }
}
