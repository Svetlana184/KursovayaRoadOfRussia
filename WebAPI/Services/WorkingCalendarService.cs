using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class WorkingCalendarService : IService<WorkingCalendar>
    {
        private readonly RoadOfRussiaKorushkContext roadOfRussiaContext;
        public WorkingCalendarService(RoadOfRussiaKorushkContext context)
        {
            this.roadOfRussiaContext = context;
        }

        public async Task<IEnumerable<WorkingCalendar>> GetAll()
        {
            return await roadOfRussiaContext.WorkingCalendars.ToListAsync();
        }

        public async Task<WorkingCalendar> GetById(int id_)
        {
            return await roadOfRussiaContext.WorkingCalendars.FindAsync(id_);
        }


        public async Task Create(WorkingCalendar product)

        {
            await roadOfRussiaContext.WorkingCalendars.AddAsync(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await roadOfRussiaContext.WorkingCalendars.FindAsync(id);
            if (product != null)
            {
                roadOfRussiaContext.WorkingCalendars.Remove(product);
                await roadOfRussiaContext.SaveChangesAsync();
            }
        }


        public async Task Update(WorkingCalendar product)
        {
            roadOfRussiaContext.Entry(product).State = EntityState.Modified;
            roadOfRussiaContext.Update(product);
            await roadOfRussiaContext.SaveChangesAsync();
        }
    }
}
