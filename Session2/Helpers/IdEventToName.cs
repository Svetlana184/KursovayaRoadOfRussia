using Desktop.Model;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Desktop.Helpers
{
    public class IdEventToName : IValueConverter
    {
        public EventService eventService;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString()!);
            return eventService.GetAll().Result.FirstOrDefault(x => x.IdEvent == id)!.EventName;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
