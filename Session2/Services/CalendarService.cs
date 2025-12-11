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
    public class CalendarService : BaseService<Calendar_>
    {
        private HttpClient httpClient;
        public CalendarService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization",
               "Bearer " + RegisterUser.access_token);
        }
        public override async Task<bool> Add(Calendar_ obj)
        {
            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await httpClient.PostAsync("https://localhost:7013/api/Calendar/post", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseText))
                    {
                        Calendar_ resp = JsonSerializer.Deserialize<Calendar_>(responseText)!;
                        if (resp != null)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Ошибка API: {error}", "Ошибка");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                return false;
            }
        }

        public override async Task<bool> Delete(Calendar_ obj)
        {
            try
            {
                using var response = await httpClient.DeleteAsync($"https://localhost:7013/api/Calendar/delete/{obj.IdCalendar}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                return false;
            }
            //using var response = await httpClient.DeleteAsync($"https://localhost:7013/api/Calendar/delete/{obj.IdCalendar}");

        }

        public override async Task<List<Calendar_>> GetAll()
        {
            return (await httpClient.GetFromJsonAsync<List<Calendar_>>("https://localhost:7013/api/Calendar/getall"))!;
        }


        public override Task<List<Calendar_>> Search(string str)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> Update(Calendar_ obj)
        {
            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await httpClient.PutAsync($"https://localhost:7013/api/Calendar/update/{obj.IdCalendar}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                return false;
            }
        }
    }
}
