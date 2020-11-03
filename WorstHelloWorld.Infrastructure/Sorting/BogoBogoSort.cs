using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using WorstHelloWorld.Infrastructure.Exceptions;

namespace WorstHelloWorld.Infrastructure.Sorting
{
    public static class BogoBogoSort
    {
        public static IEnumerable<char> Sort(IEnumerable<char> inputCollection, string expectedResult, CancellationToken token)
        {
            if (inputCollection == null || !inputCollection.Any() || expectedResult.Length != inputCollection.Count())
            {
                throw new UnbelievableException();
            }

            if (token.IsCancellationRequested)
            {
                return null;
            }

            while (!IsArraySorted(inputCollection, expectedResult, token))
            {
                new Random().Shuffle(inputCollection.ToArray());
            }
            return inputCollection;
        }

        private static bool IsArraySorted(IEnumerable<char> inputArray, string expectedResult, CancellationToken token)
        {
            var copy = new List<char>(inputArray);
            List<char> subList;

            do
            {
                new Random().Shuffle(copy);
                var subExpectedResult = RemoveCharacterFromExpectedResult(expectedResult, copy.Last());
                subList = copy.Take(copy.Count - 1).ToList();
                if (!subList.Any() || subExpectedResult.Length != subList.Count())
                {
                    break;
                }
                Sort(subList, subExpectedResult, token);
            } while ((copy.Count - 1).CompareTo(subList.Count - 1) < 0);
            var value = BuildStringFromCharArray(copy);
            return expectedResult.Contains(value);
        }

        private static string RemoveCharacterFromExpectedResult(string expectedResult, char character)
        {
            var list = expectedResult.ToCharArray().ToList();
            list.Remove(character);
            return new string(list.ToArray());
        }

        private static string BuildStringFromCharArray(IEnumerable<char> array)
        {
            var stringBuilder = new StringBuilder();
            foreach (var character in array)
            {
                stringBuilder.Append(character);
            }
            return stringBuilder.ToString();
        }

        public static void Shuffle(this Random rng, IList<char> array)
        {
            int n = array.Count();
            while (n > 1)
            {
                int k = rng.Next(n--);
                char temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        static int GetNextInt32(RNGCryptoServiceProvider rnd)
        {
            byte[] randomInt = new byte[4];
            rnd.GetBytes(randomInt);
            return Convert.ToInt32(randomInt[0]);
        }
    }
}
