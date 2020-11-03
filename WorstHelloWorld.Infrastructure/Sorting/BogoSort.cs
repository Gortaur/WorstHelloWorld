using System;
using System.Collections.Generic;
using System.Linq;
using WorstHelloWorld.Infrastructure.Exceptions;

namespace WorstHelloWorld.Infrastructure.Sorting
{
    public static class BogoSort<Type> where Type : IComparable
    {
        public static IEnumerable<Type> Sort(IEnumerable<Type> inputCollection)
        {
            if (inputCollection == null || !inputCollection.Any())
            {
                throw new UnbelievableException();
            }

            var copyOfInputCollection = inputCollection.ToArray();
            while (true)
            {
                Shuffle(copyOfInputCollection);
                if (IsArraySorted(copyOfInputCollection))
                {
                    return copyOfInputCollection;
                }
            }
        }

        private static void Shuffle(IEnumerable<Type> inputCollection)
        {
            Random random = new Random();
            inputCollection = inputCollection.OrderBy(x => random.Next()).ToArray();
        }

        private static bool IsArraySorted(IEnumerable<Type> inputArray)
        {
            var castedCollection = inputArray.ToArray();
            for (int i = 0; i < castedCollection.Length - 1; i++)
            {
                var currentElement = castedCollection[i];
                var nextElement = castedCollection[i + 1];
                if (currentElement.CompareTo(nextElement) == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
