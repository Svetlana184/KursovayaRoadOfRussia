using Microsoft.EntityFrameworkCore;
using WebAPI;

namespace WebAPI.Services
{
    public class DepartmentService : IService<Department>
    {
        private readonly RoadOfRussiaContext roadOfRussiaContext;
        public DepartmentService(RoadOfRussiaContext context)
        {
            roadOfRussiaContext = context;
        }
        public async Task Create(Department product)
        {
            await roadOfRussiaContext.Departments.AddAsync(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await roadOfRussiaContext.Departments.FirstOrDefaultAsync(p => p.IdDepartment == id);
            if (product != null)
            {
                roadOfRussiaContext.Departments.Remove(product);
                await roadOfRussiaContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await roadOfRussiaContext.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await roadOfRussiaContext.Departments.FirstOrDefaultAsync(p => p.IdDepartment == id);
        }

        public async Task Update(Department product)
        {
            roadOfRussiaContext.Update(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }
    }
}