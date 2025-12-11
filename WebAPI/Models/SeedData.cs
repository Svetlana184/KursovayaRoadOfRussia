using System;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class SeedData
    {
        public static void SeedDatabase(RoadOfRussiaKorushkContext context)
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
            }
        }
    }
}
