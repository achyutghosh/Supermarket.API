using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Resources
{
    // For creating a new category we din not have an ID> So we need a resource which has name for the category.
    // this resource class is responsible for this.
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
