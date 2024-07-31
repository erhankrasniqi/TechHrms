using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Infrastructure.Repository
{
    public class TrainingRepository : BaseRepository<Training>, ITrainingRepository
    {
        private readonly AppDbContext _dbContext;

        public TrainingRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
