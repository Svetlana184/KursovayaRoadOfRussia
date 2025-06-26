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
    public class IdEmployeeToName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                int id = int.Parse(value.ToString());
                if (id != 0)
                {

                    using (RoadOfRussiaContext db = new RoadOfRussiaContext())
                    {
                        return db.Employees.FirstOrDefault(x => x.IdEmployee == id)!.Surname + " " +
                            db.Employees.FirstOrDefault(x => x.IdEmployee == id)!.FirstName;
                    }
                }
                else return " ";
            }
            
            else return " ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
