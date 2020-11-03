using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorstHelloWorld.Infrastructure.Sorting;
using WorstHelloWorld.Interface.Core.Providers;

namespace WorstHelloWorld.Core.Providers
{
    public class HelloWorldProvider : IHelloWorldProvider
    {
        public HelloWorldProvider(IHelloWorldCharactersProvider helloWorldCharactersProvider)
        {
            _helloWorldCharactersProvider = helloWorldCharactersProvider;
        }

        public async Task<string> GetHelloWorld()
        {
            const string HelloWorld = "Hello World";
            var helloWorldCharacters = await _helloWorldCharactersProvider.GetHelloWorldCharacters();
            var helloWorldOrderedCharacters = BogoBogoSort.Sort(helloWorldCharacters, HelloWorld, new System.Threading.CancellationToken());
            return BuildStringFromCharArray(helloWorldOrderedCharacters.ToArray());
        }

        private string BuildStringFromCharArray(IEnumerable<char> array)
        {
            var stringBuilder = new StringBuilder();
            foreach (var character in array)
            {
                stringBuilder.Append(character);
            }
            return stringBuilder.ToString();
        }

        private readonly IHelloWorldCharactersProvider _helloWorldCharactersProvider;
    }
}
