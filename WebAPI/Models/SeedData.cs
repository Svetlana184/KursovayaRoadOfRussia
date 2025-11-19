using System;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class SeedData
    {
        public static void SeedDatabase(RoadOfRussiaContext context)
        {
            context.Database.Migrate();
            if (context.Departments.Count() == 0)
            {
                Department dep_start = new Department()
                {
                    DepartmentName = "start department"
                };
                context.Departments.Add(dep_start);
                context.SaveChanges();
                Employee admin_start = new Employee()
                {
                    Surname = "ad",
                    FirstName = "start",
                    Position = "administrator",
                    PhoneWork = "+0",
                    Cabinet = "0",
                    Email = "start_admin@gmail.com",
                    IdDepartment = context.Departments.FirstOrDefault(p => p.IdDepartment == 1)!.IdDepartment

                };
                context.Employees.Add(admin_start);
                context.SaveChanges();
            }
        }
    }
}
