using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorstHelloWorld.Interface.Core.Providers;
using WorstHelloWorld.Interface.Infrastructure.Repositories;

namespace WorstHelloWorld.Core.Providers
{
    public class HelloWorldCharactersProvider : IHelloWorldCharactersProvider
    {
        public HelloWorldCharactersProvider(IDesiredNumbersRepository desiredNumbersRepository)
        {
            _desiredNumbersRepository = desiredNumbersRepository;
        }

        public async Task<IEnumerable<char>> GetHelloWorldCharacters()
        {
            var desiredNumbers = (await _desiredNumbersRepository.Get().ConfigureAwait(false)).ToList();
            var resultArray = new List<char>();
            var random = new Random();
            while (true)
            {
                if (desiredNumbers.Count == 0)
                {
                    break;
                }

                var possibleChar = random.Next(0, 420);
                if (IsValidChar(possibleChar, desiredNumbers))
                {
                    resultArray.Add((char)possibleChar);
                    desiredNumbers.Remove(possibleChar);
                }
            }

            return resultArray;
        }

        private bool IsValidChar(int charId, List<int> desiredChars)
        {
            return desiredChars.Contains(charId);
        }


        private readonly IDesiredNumbersRepository _desiredNumbersRepository;
    }
}
