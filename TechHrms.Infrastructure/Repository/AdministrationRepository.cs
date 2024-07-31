using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Infrastructure.Repository
{
    
    public class AdministrationRepository : BaseRepository<Administration>, IAdministrationRepository
    {
        private readonly AppDbContext _dbContext;

        public AdministrationRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
