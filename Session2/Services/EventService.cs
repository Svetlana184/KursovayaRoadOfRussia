using Desktop.Model;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop.Services
{
    public class EventService : BaseService<Event>
    {
       
        private HttpClient httpClient;
        public EventService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization",
               "Bearer " + RegisterUser.access_token);
        }
        public override async Task Add(Event obj)
        {
            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await httpClient.PostAsync("https://localhost:7013/api/Event/post", content);
                string responseText = await response.Content.ReadAsStringAsync();
                if (responseText != null)
                {
                    Event resp = JsonSerializer.Deserialize<Event>(responseText!)!;
                    if (resp == null) MessageBox.Show(responseText);
                }
            }
            catch { }
        }

        public override async Task Delete(Event obj)
        {
            using var response = await httpClient.DeleteAsync($"https://localhost:7013/api/Event/delete/{obj.IdEvent}");

        }

        public override async Task<List<Event>> GetAll()
        {
            return (await httpClient.GetFromJsonAsync<List<Event>>("https://localhost:7013/api/Event/getall"))!;
        }


        public override Task<List<Event>> Search(string str)
        {
            throw new NotImplementedException();
        }

        public override async Task Update(Event obj)
        {
            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await httpClient.PutAsync($"https://localhost:7013/api/Event/update/{obj.IdEvent}", content);
                string responseText = await response.Content.ReadAsStringAsync();
                if (responseText != null)
                {
                    Calendar_ resp = JsonSerializer.Deserialize<Calendar_>(responseText!)!;
                    if (resp == null) MessageBox.Show(responseText);
                }

            }
            catch { }
        }
    }
}
