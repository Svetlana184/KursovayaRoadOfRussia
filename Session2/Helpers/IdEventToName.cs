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
    internal class IdEventToName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString()!);
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                return db.Events.FirstOrDefault(x => x.IdEvent == id)!.EventName;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
