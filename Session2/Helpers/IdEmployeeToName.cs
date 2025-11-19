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
                    ObservableCollection<Employee> emps;
                    employeeService = new EmployeeService();
                    try
                    {
                        emps = null!;
                        Task<List<Employee>> task = Task.Run(() => employeeService.GetAll());
                        emps = new ObservableCollection<Employee>(task.Result);
                        return emps.FirstOrDefault(x => x.IdEmployee == id)!.Surname + " " +
                            emps.FirstOrDefault(x => x.IdEmployee == id)!.FirstName;
                    }
                    catch
                    {
                        return "хз брат";
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
