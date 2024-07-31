using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Models;

namespace TechHrms.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
