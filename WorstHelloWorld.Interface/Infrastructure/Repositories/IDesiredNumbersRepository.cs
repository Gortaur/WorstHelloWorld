using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorstHelloWorld.Interface.Infrastructure.Repositories
{
    public interface IDesiredNumbersRepository
    {
        Task<IEnumerable<int>> Get();
    }
}
