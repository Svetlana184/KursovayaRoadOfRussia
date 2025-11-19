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
    public class IdEmployeeToName : IValueConverter
    {
        public EmployeeService employeeService;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                int id = int.Parse(value.ToString());
                if (id != 0)
                {

                 
                        return employeeService.GetAll().Result.FirstOrDefault(x => x.IdEmployee == id)!.Surname + " " +
                            employeeService.GetAll().Result.FirstOrDefault(x => x.IdEmployee == id)!.FirstName;
                    
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
