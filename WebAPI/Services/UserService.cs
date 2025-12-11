using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class UserService: IService<User>
    {
        private readonly RoadOfRussiaKorushkContext roadOfRussiaContext;
        public UserService(RoadOfRussiaKorushkContext context)
        {
            this.roadOfRussiaContext = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await roadOfRussiaContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id_)
        {
            return await roadOfRussiaContext.Users.FindAsync(id_);
        }


        public async Task Create(User product)

        {
            await roadOfRussiaContext.Users.AddAsync(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await roadOfRussiaContext.Users.FindAsync(id);
            if (product != null)
            {
                roadOfRussiaContext.Users.Remove(product);
                await roadOfRussiaContext.SaveChangesAsync();
            }
        }




        public async Task Update(User product)
        {
            roadOfRussiaContext.Entry(product).State = EntityState.Modified;
            roadOfRussiaContext.Update(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }
    }
}
