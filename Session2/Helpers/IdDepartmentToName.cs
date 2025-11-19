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
    public class IdDepartmentToName : IValueConverter
    {
        public DepartmentService departmentService;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString()!);
            return departmentService.GetAll().Result.FirstOrDefault(x => x.IdDepartment == id)!.DepartmentName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
