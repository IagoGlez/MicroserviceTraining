using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Application.Services;
using Training.Domain.Entities;

namespace Training.Persistence.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private ICourseContext _context;

        public CoachRepository(ICourseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Coach>> GetAllCoaches()
        {
            return await _context.Coaches.ToListAsync();
        }

        public async Task<Coach> GetCoachById(Guid id)
        {
            return await _context.Coaches.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void DeleteCoach(Guid id)
        {
            var coach = _context.Coaches.Where(x => x.Id == id).FirstOrDefault();
            if (coach != null)
            {
                _context.Coaches.Remove(coach);
                _context.SaveChangesAsync();
                throw new ApplicationException("test");
            }
        }

        public async Task CreateCoach(Coach coach)
        {
            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCoach(Coach coach)
        {
            var coachActualizar = await _context.Coaches.Where(x => x.Id == coach.Id).FirstOrDefaultAsync();
            if (coachActualizar != null)
            {
                coachActualizar.Name = coach.Name;
                coachActualizar.ExperienceYears = coach.ExperienceYears;
                coachActualizar.EmailAddress = coach.EmailAddress;
                coachActualizar.RollOnDate = coach.RollOnDate;
                coachActualizar.CommunityName = coach.CommunityName;
            }

            await _context.SaveChangesAsync();
        }
    }
}
