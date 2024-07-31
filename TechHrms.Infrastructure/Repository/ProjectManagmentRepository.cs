using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Infrastructure.Repository
{
     
    public class ProjectManagmentRepository : BaseRepository<ProjectManagment>, IProjectManagmentRepository
    {
        private readonly AppDbContext _dbContext;

        public ProjectManagmentRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
