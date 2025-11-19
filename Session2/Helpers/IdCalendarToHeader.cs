
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Desktop.Model;
using Desktop.Services;

namespace Desktop.Helpers
{
    public class IdCalendarToHeader : IValueConverter
    {
        public CalendarService calendarService;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString()!);

            ObservableCollection<Calendar_> calendars;
            calendarService = new CalendarService();
            try
            {
                calendars = null!;
                Task<List<Calendar_>> task = Task.Run(() => calendarService.GetAll());
                calendars = new ObservableCollection<Calendar_>(task.Result);
                string header = calendars.FirstOrDefault(x => x.IdCalendar == id)!.DateStart!.ToString() +
                     " - " + calendars.FirstOrDefault(x => x.IdCalendar == id)!.DateFinish!.ToString();
                return header;
            }
            catch
            {
                return "хз брат";
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
