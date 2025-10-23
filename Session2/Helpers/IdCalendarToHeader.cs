﻿using Session2.Model;
using Session2.Services;
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
        public CalendarService calendarService;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString()!);

            string header = calendarService.GetAll().Result.FirstOrDefault(x => x.IdCalendar == id)!.DateStart!.ToString() +
                    " - " + calendarService.GetAll().Result.FirstOrDefault(x => x.IdCalendar == id)!.DateFinish!.ToString();
                return header;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
