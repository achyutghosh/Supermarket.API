namespace Supermarket.API.Resources
{
    // We don’t want this property in our response, but we can’t change our model class to exclude this property.
    // It would cause EF Core to throw errors when we try to manage categories data, and 
    // it would also break our domain model design 
    // because it does not make sense to have a product category that doesn’t have products.
    // To return JSON data containing only the identifiers and names of the supermarket categories, we have to create a resource class.
    // A resource class is a class that contains only basic information that will be exchanged between client applications and 
    // API endpoints, generally in form of JSON data, to represent some particular information.

    public class CategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}