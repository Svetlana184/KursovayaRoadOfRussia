using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class CalendarService : IService<Calendar_>
    {
        private readonly RoadOfRussiaKorushkContext roadOfRussiaContext;
        public CalendarService(RoadOfRussiaKorushkContext context)
        {
            this.roadOfRussiaContext = context;
        }

        public async Task<IEnumerable<Calendar_>> GetAll()
        {
            return await roadOfRussiaContext.Calendars.ToListAsync();
        }

        public async Task<Calendar_> GetById(int id_)
        {
            return await roadOfRussiaContext.Calendars.FindAsync(id_);
        }


        public async Task Create(Calendar_ product)

        {
            await roadOfRussiaContext.Calendars.AddAsync(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await roadOfRussiaContext.Calendars.FindAsync(id);
            if (product != null)
            {
                roadOfRussiaContext.Calendars.Remove(product);
                await roadOfRussiaContext.SaveChangesAsync();
            }
        }




        public async Task Update(Calendar_ product)
        {
            roadOfRussiaContext.Entry(product).State = EntityState.Modified;
            roadOfRussiaContext.Update(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }
    }
}
