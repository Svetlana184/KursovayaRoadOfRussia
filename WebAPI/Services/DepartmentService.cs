using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class DepartmentService : IService<Department>
    {
        private readonly RoadOfRussiaKorushkContext roadOfRussiaContext;
        public DepartmentService(RoadOfRussiaKorushkContext context)
        {
            this.roadOfRussiaContext = context;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await roadOfRussiaContext.Departments.ToListAsync();
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
            roadOfRussiaContext.Entry(product).State = EntityState.Modified;
            roadOfRussiaContext.Update(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }
    }
}