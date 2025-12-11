using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop.Services
{
    public class WorkingCalendarService : BaseService<WorkingCalendar>
    {
        private HttpClient httpClient;
        public WorkingCalendarService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization",
               "Bearer " + RegisterUser.access_token);
        }
        public override async Task<bool> Add(WorkingCalendar obj)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> Delete(WorkingCalendar obj)
        {
            throw new NotImplementedException();

        }

        public override async Task<List<WorkingCalendar>> GetAll()
        {
            return (await httpClient.GetFromJsonAsync<List<WorkingCalendar>>("https://localhost:7013/api/WorkingCalendar/getall"))!;
        }


        public override Task<List<WorkingCalendar>> Search(string str)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> Update(WorkingCalendar obj)
        {
            throw new NotImplementedException();
        }
    }
}
