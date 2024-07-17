using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Domain.Entities;

namespace Training.Application.Services
{
    public interface ICoachRepository
    {
        Task<IEnumerable<Coach>> GetAllCoaches();
        Task<Coach> GetCoachById(Guid id);
        void DeleteCoach(Guid id);
        Task CreateCoach(Coach coach);
        Task UpdateCoach(Coach coach);
    }
}
