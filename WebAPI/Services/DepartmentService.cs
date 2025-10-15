﻿using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class DepartmentService : IService<Department>
    {
        private readonly RoadOfRussiaContext roadOfRussiaContext;
        public DepartmentService(RoadOfRussiaContext context)
        {
            this.roadOfRussiaContext = context;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await roadOfRussiaContext.Departments.ToArrayAsync();
        }

        public async Task<Department> GetById(int id_)
        {
            return await roadOfRussiaContext.Departments.FindAsync(id_);
        }


        public async Task Create(Department product)

        {
            await roadOfRussiaContext.Departments.AddAsync(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await roadOfRussiaContext.Departments.FindAsync(id);
            if (product != null)
            {
                roadOfRussiaContext.Departments.Remove(product);
                await roadOfRussiaContext.SaveChangesAsync();
            }
        }

        

        
        public async Task Update(Department product)
        {
            roadOfRussiaContext.Update(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }
    }
}