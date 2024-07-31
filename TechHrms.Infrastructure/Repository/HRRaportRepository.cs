using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Infrastructure.Repository
{
    public class HRRaportRepository : BaseRepository<HRRaport>, IHRRaportRepository
    {
        private readonly AppDbContext _dbContext;

        public HRRaportRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}