using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        // This constructor is going to pass the success and message parameters to the base class, 
        // and also sets the Category property
        private CategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        /// <summary>
        /// This constrictor receives only the category as a parameter. 
        /// This one will create a successful response, 
        /// calling the private constructor to set the respective properties
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public CategoryResponse(Category category) : this(true, string.Empty, category)
        { }

        /// <summary>
        /// This constrictor only specifies the message. 
        /// This one will be used to create a failure response
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CategoryResponse(string message) : this(false, message, null)
        { }
    }
}

