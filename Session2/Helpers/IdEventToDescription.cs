using Desktop.Model;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Desktop.Helpers
{
    public class IdEventToDescription : IValueConverter
    {
        public EventService eventService;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                try
                {
                    int id = int.Parse(value.ToString()!);
                    ObservableCollection<Event> evs;
                    eventService = new EventService();
                    evs = null!;
                    Task<List<Event>> task = Task.Run(() => eventService.GetAll());
                    evs = new ObservableCollection<Event>(task.Result);
                    return evs.FirstOrDefault(x => x.IdEvent == id)!.EventDescription;
                }
                catch
                {
                    return "хз брат";
                }
            }
            else return "";
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
