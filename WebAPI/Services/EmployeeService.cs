﻿using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class EmployeeService : IService<Employee>
    {
        private readonly RoadOfRussiaContext roadOfRussiaContext;
        public EmployeeService(RoadOfRussiaContext context)
        {
            this.roadOfRussiaContext = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await roadOfRussiaContext.Employees.ToArrayAsync();
        }

        public async Task<Employee> GetById(int id_)
        {
            return await roadOfRussiaContext.Employees.FindAsync(id_);
        }


        public async Task Create(Employee product)

        {
            await roadOfRussiaContext.Employees.AddAsync(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await roadOfRussiaContext.Employees.FindAsync(id);
            if (product != null)
            {
                roadOfRussiaContext.Employees.Remove(product);
                await roadOfRussiaContext.SaveChangesAsync();
            }
        }

        public async Task Update(Employee product)
        {
            roadOfRussiaContext.Update(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }
    }
}
