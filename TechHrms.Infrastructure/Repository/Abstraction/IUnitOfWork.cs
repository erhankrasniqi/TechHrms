using System.Threading;
using System.Threading.Tasks;

namespace TechHrms.Infrastructure.Repository.Abstraction
{
    public interface IUnitOfWork
    {
        Task<int> Save(CancellationToken cancellationToken = default);
    }
}
