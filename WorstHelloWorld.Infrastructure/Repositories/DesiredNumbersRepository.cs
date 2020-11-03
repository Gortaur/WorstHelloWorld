using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WorstHelloWorld.Infrastructure.Exceptions;
using WorstHelloWorld.Interface.Infrastructure.Repositories;
using WorstHelloWorld.SharedEntities.Entities.Constants;

namespace WorstHelloWorld.Infrastructure.Repositories
{
    public class DesiredNumbersRepository : IDesiredNumbersRepository
    {
        public Task<IEnumerable<int>> Get() 
        {
            const string DesiredNumbersCollection = nameof(DesiredNumbersCollection);
            var desiredNumbers = new DesiredNumbers();
            var desiredNumbersFieldValue = GetPropertyValueFromType(desiredNumbers, DesiredNumbersCollection);

            if (desiredNumbersFieldValue == null)
            {
                throw new UnbelievableException();
            }
            if(desiredNumbersFieldValue is IEnumerable<int>) 
            {
                return Task.FromResult(desiredNumbersFieldValue as IEnumerable<int>);
            }

            throw new UnbelievableException();
        }

        private object GetPropertyValueFromType(object instance, string fieldName) 
        {
            var allFields = instance.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var desiredField = allFields.Where(field => field.Name.Equals(fieldName)).First();
            var desiredFieldValue = desiredField.GetValue(instance);
            return desiredFieldValue;
        }
    }
}
