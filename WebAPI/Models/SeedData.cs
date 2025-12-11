using System;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class SeedData
    {
            public static void SeedDatabase(RoadOfRussiaKorushkContext context)
            {
                if (!context.Departments.Any())
                {
                    Department dep_start = new Department()
                    {
                        DepartmentName = "start department"
                    };
                    context.Departments.Add(dep_start);
                    context.SaveChanges();
                    Console.WriteLine("Added start department");
                }
                if (!context.WorkingCalendars.Any())
                {
                    var calendars = new List<WorkingCalendar>
                    {
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-01-01")), IsWorkingDay = false, Id=1 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-01-02")), IsWorkingDay = false, Id=2 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-01-03")), IsWorkingDay = false, Id=3 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-01-06")), IsWorkingDay = false, Id=4 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-01-07")), IsWorkingDay = false, Id=5 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-01-08")), IsWorkingDay = false, Id=6 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-05-01")), IsWorkingDay = false, Id=7 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-05-02")), IsWorkingDay = false, Id=8 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-05-08")), IsWorkingDay = false, Id=9 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-05-09")), IsWorkingDay = false, Id=10 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-06-07")), IsWorkingDay = false, Id=11 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-06-12")), IsWorkingDay = false, Id=12 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-06-13")), IsWorkingDay = false, Id=13 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-11-01")), IsWorkingDay = true, Id=14 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-11-03")), IsWorkingDay = false, Id=15 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-11-04")), IsWorkingDay = false, Id=16 },
                    new WorkingCalendar { ExceptionDate = DateOnly.FromDateTime(DateTime.Parse("2025-12-31")), IsWorkingDay = false, Id=17 }
                    };

                    context.WorkingCalendars.AddRange(calendars);
                    context.SaveChanges();
                    Console.WriteLine($"Added {calendars.Count} working calendar entries");
                }              
            }
        }
    }
