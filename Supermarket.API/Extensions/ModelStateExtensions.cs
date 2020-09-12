using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Extensions
{
    public static class ModelStateExtensions
    {
        // This is an extension method that extends the functionality of an already existing class or interface.
        // All extension methods should be static, as well as the classes where they are declared. 
        // It means they don’t handle specific instance data and that they’re loaded only once when the application starts.

        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();
        }
    }

}
