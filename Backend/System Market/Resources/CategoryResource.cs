using Super_Market.Domain.Models;
using System.Collections.Generic;

namespace Super_Market.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ProductResource> Products { get; set; }
        
    }
}