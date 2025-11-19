using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class EventService : IService<Event>
    {
        private readonly RoadOfRussiaContext roadOfRussiaContext;
        public EventService(RoadOfRussiaContext context)
        {
            this.roadOfRussiaContext = context;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await roadOfRussiaContext.Events.ToListAsync();
        }

        public async Task<Event> GetById(int id_)
        {
            return await roadOfRussiaContext.Events.FindAsync(id_);
        }


        public async Task Create(Event product)

        {
            await roadOfRussiaContext.Events.AddAsync(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await roadOfRussiaContext.Events.FindAsync(id);
            if (product != null)
            {
                roadOfRussiaContext.Events.Remove(product);
                await roadOfRussiaContext.SaveChangesAsync();
            }
        }

        public async Task Update(Event product)
        {
            roadOfRussiaContext.Entry(product).State = EntityState.Modified;
            roadOfRussiaContext.Update(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }
    }
}
