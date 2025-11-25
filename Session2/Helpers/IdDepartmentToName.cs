using Desktop.Model;
using Desktop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Desktop.Helpers
{
    public class IdDepartmentToName : IValueConverter
    {
        public DepartmentService departmentService;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString()!);
            ObservableCollection<Department> departments;
            departmentService = new DepartmentService();

                departments = null!;
                Task<List<Department>> task = Task.Run(() => departmentService.GetAll());
                departments = new ObservableCollection<Department>(task.Result);
                if(departments.FirstOrDefault(x => x.IdDepartment == id) != null)
                {
                    return departments.FirstOrDefault(x => x.IdDepartment == id)!.DepartmentName;
                }
                return departments.First().DepartmentName;
            
             
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
