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
    public class IdDepartmentToName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString()!);
            using (RoadOfRussiaContext db = new RoadOfRussiaContext())
            {
                return db.Departments.FirstOrDefault(x => x.IdDepartment == id)!.DepartmentName;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
