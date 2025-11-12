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
    public class EventService : BaseService<Event>
    {
        private HttpClient client;
        public EventService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization",
                "Bearer" + RegisterUser.access_token);
        }
        public override async Task<bool> Add(Event obj)
        {
            await client.PostAsJsonAsync<Event>("https://localhost:7013/api/Event/post", obj);
            return true;
        }

        public override async Task<bool> Delete(Event obj)
        {
            await client.DeleteFromJsonAsync<Event>($"https://localhost:7013/api/Event/delete/{obj.IdEvent}");
            return true;
        }

        public override async Task<List<Event>> GetAll()
        {
            List<Event>? evs = await client.GetFromJsonAsync<List<Event>>("https://localhost:7013/api/Event/getall");
            return evs!;
        }

        public override async Task<bool> Update(Event obj)
        {
            await client.PutAsJsonAsync<Event>($"https://localhost:7013/api/Event/update/{obj.IdEvent}", obj);
            return true;
        }
    }
}
