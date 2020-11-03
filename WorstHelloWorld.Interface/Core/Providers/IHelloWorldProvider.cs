using System.Threading.Tasks;

namespace WorstHelloWorld.Interface.Core.Providers
{
    public interface IHelloWorldProvider
    {
        Task<string> GetHelloWorld();
    }
}
