using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorstHelloWorld.Interface.Core.Providers
{
    public interface IHelloWorldCharactersProvider
    {
        Task<IEnumerable<char>> GetHelloWorldCharacters();
    }
}
