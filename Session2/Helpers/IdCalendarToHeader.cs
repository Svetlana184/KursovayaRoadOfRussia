using Session2.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Session2.Helpers
{
    public class IdCalendarToHeader : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString()!);
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                string header = db.Calendars.FirstOrDefault(x => x.IdCalendar == id)!.DateStart.ToString() +
                    " - " + db.Calendars.FirstOrDefault(x => x.IdCalendar == id)!.DateFinish.ToString();
                return header;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
