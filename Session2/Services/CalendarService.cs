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
    public class CalendarService : BaseService<Calendar_>
    {
        private HttpClient client;
        public CalendarService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization",
                "Bearer" + RegisterUser.access_token);
        }
        public override async Task<bool> Add(Calendar_ obj)
        {
            await client.PostAsJsonAsync<Calendar_>("https://localhost:7013/api/Calendar/post", obj);
            return true;
        }

        public override async Task<bool> Delete(Calendar_ obj)
        {
            await client.DeleteFromJsonAsync<Calendar_>($"https://localhost:7013/api/Calendar/delete/{obj.IdCalendar}");
            return true;
        }

        public override async Task<List<Calendar_>> GetAll()
        {
            List<Calendar_>? calendars = await client.GetFromJsonAsync<List<Calendar_>>("https://localhost:7013/api/Calendar/getall");
            return calendars!;
        }

        public override async Task<bool> Update(Calendar_ obj)
        {
            await client.PutAsJsonAsync<Calendar_>($"https://localhost:7013/api/Calendar/update/{obj.IdCalendar}", obj);
            return true;
        }
    }
}
